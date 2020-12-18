class Train:

    def num_seats(self):
        """
        method that return the number of seats in the train
        """
        wagon, seats = self.seating_plan()
        return len(wagon) * len(seats)
