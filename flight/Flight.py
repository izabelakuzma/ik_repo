class Flight:
    def __init__(self, number, aircraft):
        if not number[:2].isalpha():
            raise ValueError("No airline code in '{}'".format(number))
        if not number[:2].isupper():
            raise ValueError("Invalid airline code '{}'".format(number))
        #zamiast try_catch
        if not (number[2:].isdigit() and int(number[2:]) <= 9999):
            raise ValueError("Invalid route number '{}'".format(number))

        self._number = number #self -> stworzenie pola w instancji klasy  __number i przypisujemy wartość
        self._aircraft = aircraft

        #rozpakować tuple tuple unpacking
        rows, seats = self._aircraft.seating_plan()
        self._seating =[None] + [{letter: None for letter in seats} for _ in rows] #dummy name


    def number(self): #definiowanie metody
        return self._number

    def airline(self):
        return self._number[:2]

    def aircraft_model(self):
        return  self._aircraft.model()


    def _parse_seat(self,seat):
        row_numbers, seat_letters = self._aircraft.seating_plan()
        letter = seat[-1]
        if letter not in seat_letters:
            raise ValueError("Invalid seat letter {}".format(letter))
        row_text = seat[:-1]
        try:
            row = int(row_text)
        except ValueError:
            raise ValueError("Invalid seat row {}".format(row_text))

        if row not in row_numbers:
            raise ValueError("Invalid row number {}".format(row))

        return row, letter

    def allocate_seat(self, seat="12C", passenger="Pawel"):

        row, letter = self._parse_seat(seat)

        if self._seating[row][letter] is not None:
            raise ValueError("Seat {} already occupied".format(seat))

        self._seating[row][letter] = passenger

    def relocate_passenger(self, from_seat, to_seat):
        from_row, from_letter = self._parse_seat(from_seat)
        if self._seating[from_row][from_letter] is None: #dwuwymiarowa lista
            raise ValueError("No passenger to relocate in seat {}".format_map(from_seat))

        to_row, to_letter = self._parse_seat(to_seat)
        if self._seating[to_row][to_letter] is not None:
            raise ValueError("Seat {} already occupied", format(to_seat))
        self._seating[to_row][to_letter] = self._seating[from_row][from_letter]
        self._seating[from_row][from_letter] = None


    def num_available_seats(self):
        return sum(sum(1 for seats in row.values() if seats is None)
                   for row in self._seating
                   if row is not None)        #liczba wolnych miejsc, 3 comprehension i generator

    def make_boarding_cards(self, card_printer):
        for passenger, seat in sorted(self._passenger_seat()): #sorted nie modyfikuje danych , gen comprehension
            card_printer(passenger, seat, self.number(), self.aircraft_model())


    def _passenger_seat(self):
        row_numbers, seat_letters = self._aircraft.seating_plan()
        for row in row_numbers:
            for letter in seat_letters:
                passenger = self._seating[row][letter]
                if passenger is not None:
                    yield(passenger, "{}{}".format(row, letter))

