import numpy as np


def get_data(path):
    try:
        file = open(path, 'r')
        data = file.read().strip()
        data = data[0:len(data)]
        split_data = data.split(", ")
    except:
        print("Error loading the file")
    return split_data


def save_data(arr_output):
    try:
        arr_output = np.asarray(arr_output)
        np.savetxt("file.txt", arr_output.flatten(), fmt='%d', newline=", ")
        print('Saved array in the file.txt')
    except:
        print("Error saving the file")
