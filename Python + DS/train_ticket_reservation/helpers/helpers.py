def console_ticket_printer(passenger, seat, number, train):
    """
    method that print ticket for the passenger
    :param: paasenger, seat, number , train
    """
    output = "| Name: {0}" \
             "  Ticket number: {1}" \
             "  Seat: {2}" \
             "  Wagon: {3}" \
             "  Train: {4}" \
             " |".format(passenger, number, seat, seat[0], train)
    banner = '+' + '-' * (len(output) - 2) + '+'
    border = '|' + ' ' * (len(output) - 2) + '|'
    lines = [banner, border, output, border, banner]
    card = '\n'.join(lines)
    print(card)
    print()
