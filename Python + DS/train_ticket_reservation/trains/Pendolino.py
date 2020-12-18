from train_base import Train


class Pendolino(Train):
    """
    Inherits from the base class - Train.
    """

    def model(self):
        """
        return string: train model
        """
        return "Pendolino"

    def seating_plan(self):
        """
        return tuple with possible combinations of seats in the train,
        the first digit is the number of the wagon,
        the second digit is the seat (1,8)
        """
        return range(1, 10), range(1, 9)
