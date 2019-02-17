from airplane import *
from planes import *
from flight import *
from helpers import *


def make_flight():

    f = Flight("BA758", AirbusA319("G-EUPT"))
    print(f.number())
    print(f.airline)
    print(f.aircraft_model())
    f.allocate_seat('12D', 'Izabela')
    f.allocate_seat('20A', 'Julia')
    f.allocate_seat('10A', 'Anna')
    print(f.num_available_seats())
    f.make_boarding_cards(console_card_printer)


    g = Flight("AF72", Boeing777("F-GSPS"))
    print(g.number())
    print(g.airline)
    print(g.airline())




make_flight()