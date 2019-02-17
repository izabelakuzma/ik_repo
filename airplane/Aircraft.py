class Aircraft: #tworzymy identyfikator klasy
    def __init__(self, registration): #wywołany w momencie tworzenia instancji
        self._registration = registration

    def registration(self):
        return self._registration #zwraca wartość registration

    def num_seats(self):
        rows, row_seats = self.seating_plan()
        return len(rows) * len(row_seats)