import unittest

from classes import pairSum
from classes.pairSum import PairSum


class TestPairSum(unittest.TestCase):
    def setUp(self):
        self.pairSum = PairSum()

    def test_pairs(self):
        arr = [4, 8, 9, 0, 12, 1, 4, 2, 12, 12, 4, 4, 8, 11, 12, 0]
        result = self.pairSum.return_sum(arr)

        self.assertEqual(result, [8, 4, 12, 0, 8, 4, 11, 1, 0, 12])

    def test_without_pairs(self):
        arr = [1, 2, 4, 1]
        result = self.pairSum.return_sum(arr)

        self.assertEqual(result, [])
