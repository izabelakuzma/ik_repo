from helpers import *
from trains import *
from journeys import *
from helpers import *



def train_journey():
    e = Journeys("EIC1936789732", ExpressInterCity())
    print(e.number())
    print(e.train_model())
    e.allocate_seats('Izabela', '24')
    e.allocate_seats('Adam', '22')
    e.allocate_seats('Marta', '32')
    e.allocate_seats('Daniel', '25')
    e.allocate_seats('Jacek', '42')
    print("Available seats : " + str(e.available_seats()))
    e.relocate_passenger('32', '63')
    print(list(e.passenger_seat()))
    e.make_ticket(console_ticket_printer)

    p = Journeys("PEN1936789732", Pendolino())
    print(p.number())
    print(p.train_model())


train_journey()