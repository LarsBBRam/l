number = 1
number2 = 2

print(number + number2)

print(1+2)

number = 'hello'


def sum_two_numbers(num: int, num2: int) -> int:
    return num + num2

result = sum_two_numbers(1,2)
print(result)

class MyClass:
    age: str
    id: int
    def __init__(self, age: str, id: int):
        self.age = age
        self.id = id
        pass
