from basic import *
from train_base import *
from trains import *
import unittest

from trains.ExpressInterCity import ExpressInterCity
from trains.Pendolino import Pendolino


class TestTrain(unittest.TestCase):



    def test_available_seat(self):

        e = Journeys("EIC1936789732", ExpressInterCity())
        e.allocate_seats('Izabela', '24')
        e.allocate_seats('Anna', '25')
        self.assertEqual(e.available_seats(), 52)
        #self.assertEqual(train.Journeys.available_seats(e.allocate_seats)) == 53

    def test_model(self):
        p = train.Journeys("PEN2948796059", Pendolino())
        self.assertEqual(p.train_model(), "Pendolino")

    def test_alocate_passenger(self):
        e = train.Journeys("EIC1936789732", ExpressInterCity())
        e.allocate_seats('Izabela', '24')
        self.assertRaises(ValueError, e.allocate_seats('Izabela', '24'), '24')


    def test_relocate_passenger(self):
        e = train.Journeys("EIC1936789732", ExpressInterCity())
        e.allocate_seats('Izabela', '24')
        self.assertEqual(e.relocate_passenger('24','55'), None)
        self.assertRaises(ValueError, e.allocate_seats('Izabela', '55'), '55')




if __name__ == '__main__':
    if __name__ == '__main__':
        unittest.main()
