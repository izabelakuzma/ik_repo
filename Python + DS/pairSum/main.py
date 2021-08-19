from classes.pairSum import PairSum
from helpers.helpers import get_data, save_data

arr = get_data('array.txt')


pairSum = PairSum()
arr_output = pairSum.return_sum(arr)

save_data(arr_output)


