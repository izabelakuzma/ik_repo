##### 1. Config #####

library(dplyr)
library(ggplot2)
library(gridExtra)
library(httr)
library(jsonlite)
library(lubridate)
library(scales)
library(shiny)
library(tidyr)

key = 'ZvpB9LkwUsixWDuyfbK5yJCYxFNd3O1P'
coords = data.frame(city = c('Białystok', 'Warszawa'),
                    lat = c(53.1325, 52.2297),
                    lng = c(23.1688, 21.0122))

##### 2. Defining app components #####

ui = fluidPage(
  titlePanel('Air quality'),
  sidebarLayout(
    sidebarPanel(
      selectInput('city', 'Select city', c('Białystok', 'Warszawa')),
    ),
    mainPanel(
      plotOutput(outputId = 'airQualPlot')
    )
  )
)

server = function(input, output) {
  output$airQualPlot = renderPlot({
    # extracting data
    url = paste0('https://airapi.airly.eu/v2/measurements/point?lat=',
                 coords[coords == input$city, 'lat'], '&lng=',
                 coords[coords == input$city, 'lng'])
    raw = GET(url, add_headers(apikey = key))
    data = fromJSON(content(raw, 'text'))
    (hist = as.data.frame(data$history))
    # processing data
    vals = bind_rows(hist$values, .id = 'row_id') %>% 
      mutate(row_id = as.numeric(row_id))
    (from = parse_date_time(hist$fromDateTime, 'y m d H M S') %>% 
        with_tz(tz = 'CET'))
    (till = parse_date_time(hist$tillDateTime, 'y m d H M S') %>% 
        with_tz(tz = 'CET'))
    (dates = data.frame(row_id = 1:24, from, till))
    pm = vals %>% 
      left_join(dates, by = 'row_id') %>%
      select(row_id, from, till, name, value) %>% 
      mutate(name = as.factor(name)) %>% 
      filter(substr(name, 1, 2) == 'PM')
    now = data$current$values
    time = parse_date_time(data$current$tillDateTime, 'y m d H M S') %>% 
      with_tz(tz = 'CET')
    # producing plots
    today = format(max(pm$till), '%d %B')
    yesterday = format(min(pm$till), '%d %B')
    p1 = ggplot(data = pm, aes(x = till)) +
      geom_line(aes(y = value, col = reorder(name, value)), size = 1.5) +
      scale_color_manual(values = c('orangered', 'red2', 'red4'), 
                         labels = c('PM 1', 'PM 2.5', 'PM 10')) +
      scale_x_datetime(labels = date_format('%H:%M', tz = 'CET')) +
      labs(x = '', y = '') +
      annotate('text', label = yesterday, x = min(pm$from), y = max(pm$value), 
               hjust = 0, vjust = 1, size = 5, col = 'grey40') +
      annotate('text', label = today, x = max(pm$till), y = max(pm$value), 
               hjust = 1, vjust = 1, size = 5, col = 'grey40') +
      theme(axis.ticks = element_blank(), 
            axis.text = element_text(size = 14),
            legend.position = 'bottom',
            legend.text = element_text(size = 18),
            legend.title = element_blank())
    p2 = ggplot() +
      scale_x_continuous(limits = c(0, 1)) +
      scale_y_continuous(limits = c(0, 1)) +
      annotate('text', label = paste('miasto:', input$city),
               x = 0, y = 0.97, hjust = 0, size = 7) +
      annotate('text', label = paste('warunki dnia', format(time, '%d.%m'),
                                     'godz.', format(time, '%H:%M')),
               x = 0, y = 0.86, hjust = 0, size = 7, col = 'grey40') +
      annotate('text', label = paste('PM 10 =', now$value[3], 'ug/m3'),
               x = 0, y = 0.75, hjust = 0, size = 7, col = 'red4') +
      annotate('text', label = paste('PM 2.5 =', now$value[2], 'ug/m3'),
               x = 0, y = 0.64, hjust = 0, size = 7, col = 'red2') +
      annotate('text', label = paste('PM 1 =', now$value[1], 'ug/m3'),
               x = 0, y = 0.53, hjust = 0, size = 7, col = 'orangered') +
      annotate('text', label = paste('temperatura =', round(now$value[6], 1), 'st. C'),
               x = 0, y = 0.42, hjust = 0, size = 7, col = 'darkblue') +
      annotate('text', label = paste('ciśnienie =', round(now$value[4]), 'hPa'),
               x = 0, y = 0.31, hjust = 0, size = 7, col = 'blue') +
      annotate('text', label = paste0('wilgotność = ', round(now$value[5]), '%'),
               x = 0, y = 0.2, hjust = 0, size = 7, col = 'dodgerblue') +
      theme_void()
    # showing plots
    grid.arrange(p1, p2, nrow = 1, ncol = 2)
  })
}

##### 3. Running an app #####

shinyApp(ui, server)
