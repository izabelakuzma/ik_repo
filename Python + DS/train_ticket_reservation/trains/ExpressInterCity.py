from train_base import Train


class ExpressInterCity(Train):
    """
    Inherits from the base class - Train.
    """

    def model(self):
        """
        return train model as string
        """
        return "EIC"

    def seating_plan(self):
        """
        return tuple with possible combinations of seats in the train,
        the first digit is the number of the wagon,
        the second digit is the seat number in the train compartment (1,6)
        """
        return range(1, 10), range(1, 7)
