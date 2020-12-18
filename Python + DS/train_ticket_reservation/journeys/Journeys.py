class Journeys:

    def __init__(self, number, train):
        """the method is called when an objcet is created from the Journeys class.

        :param number => ticket number, train => type of train
        :return: none
        """
        if not number[:3].isalpha():
            raise ValueError("Invalid ticket number: {}".format(number))
        if not number[:3].isupper():
            raise ValueError("Invalid ticket number: {}".format(number))
        if not number[3:].isdigit():
            raise ValueError("Invalid ticket number {}".format(number))

        self._train = train
        self._number = number

        """
        unpacking the tuple with the numbers of seats
        in the train
        """
        wagon, place = self._train.seating_plan()
        self._seating = [None] + [{num: None for num in place} for _ in wagon]

    def number(self):
        """
        :return _number: the ticket number,
        the first three characters are uppercase letters,
        the next ten characters are numbers from 0 to 9.
        """
        return self._number

    def train_model(self):
        return self._train.model()

    def parse_seat(self, seat):
        """
        the method check, if the seat number is correct
        :param seat
        :return wagon, seat => wagon number, seat number
        """
        wagon_number, seat_number = self._train.seating_plan()
        wag_no = seat[0]
        try:
            wagon = int(wag_no)
        except ValueError:
            raise ValueError("Invalid wagon number {}".format(wag_no))
        if wagon not in wagon_number:
            raise ValueError("Invalid wagon number {}".format(wagon))

        seat_no = seat[1]
        try:
            seats = int(seat_no)
        except ValueError:
            raise ValueError("Invalid seat number {}".format(seat_no))
        if seats not in seat_number:
            raise ValueError("Invalid seat number  {}".format(seats))
        return wagon, seats

    def allocate_seats(self, passenger, seat):
        """
        the method that assigns an empty seat on the trains to the passenger
        :param: passenger, seat.
        """
        wagon, number = self.parse_seat(seat)
        if self._seating[wagon][number] is not None:
            raise ValueError("Seat {} already occupied".format(seat))

        self._seating[wagon][number] = passenger

    def available_seats(self):
        """
        the method that counts the available places on the train
        """
        return sum(sum(1 for seats in wagon.values() if seats is None)
                for wagon in self._seating
                if wagon is not None)

    def passenger_seat(self):
        """
        generator that returns the train passengers and seats assigned to them
        """
        wagon, place = self._train.seating_plan()
        for wag in wagon:
            for pl in place:
                passenger = self._seating[wag][pl]
                if passenger is not None:
                    yield (passenger, "{}{}".format(wag, pl))

    def relocate_passenger(self, from_seat, to_seat):
        """
        method that turns a passenger's seat
        :param: from_seat, to_seat
        return: None
        """
        from_wagon, from_number = self.parse_seat(from_seat)
        if self._seating[from_wagon][from_number] is None:
            raise ValueError("error")

        to_wagon, to_number = self.parse_seat(to_seat)
        if self._seating[to_wagon][to_number] is not None:
            raise ValueError("The seat is already occupied {}".format(to_seat))

        self._seating[to_wagon][to_number] = self._seating[from_wagon][from_number]
        self._seating[from_wagon][from_number] = None

    def make_ticket(self, ticket_printer):
        """
        :param: ticket_priner => method that prints a ticket for the passenger
        """
        for passenger, seat in sorted(self.passenger_seat()):  # sorted nie modyfikuje danych , gen comprehension
            ticket_printer(passenger, seat, self.number(), self.train_model())
