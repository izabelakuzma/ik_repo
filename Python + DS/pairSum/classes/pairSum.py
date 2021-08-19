import numpy as np


class PairSum:
    def return_sum(self, arr):

        arr = [int(i) for i in arr]
        arr = np.asarray(arr)
        lst = []

        diff_hash = {}
        expected_sum = 12
        for i in arr:
            if diff_hash.__contains__(i):
                if i < diff_hash[i]:
                    lst.append(i)
                    lst.append(diff_hash[i])
                else:
                    print(diff_hash[i], i)
                    lst.append(i)
                    lst.append(diff_hash[i])

                diff_hash.pop(i)
                continue
            key = expected_sum - i
            diff_hash[key] = i
        return lst
