// 
// функции и константы
//

// заполнение рандомными данными (в диапозоне 0-10000)
void fillArrayRandom(int[] mas, int size)
{
  for(int i = 0; i < size; i++)
  {
    mas[i] = new Random().Next(0,10000);
  }
}
// заполнение массива вручную
void fillArrayManual(int[] mas, int size)
{
  for(int i = 0; i < size; i++)
  {
    Console.Write($"[{i}] ");
    mas[i] = int.Parse(Console.ReadLine());
  }
}
// вывод массива
void printArray(int[] mas, int size)
{
  for(int i = 0; i < size; i++)
  {
    Console.WriteLine($"[{i}] = {mas[i]}");
  }
}
// удалить элемент со сдвигом влево
void removeItem(int[] mas, int size, int index)
{
  for(int i = index + 1; i < size; i++)
  {
    mas[i - 1] = mas[i];
  }
}
// поменять элементы массива местами
void swapItems(int[] mas, int size, int i1, int i2)
{
  int temp = mas[i1];
  mas[i1] = mas[i2];
  mas[i2] = temp;
}
// добавить элемент в массив со сдвигом вправо
void addItem(int[] mas, int size, int value, int index)
{
  for(int i = size - 1; i > index; i--)
  {
    mas[i] = mas[i - 1];
  }
  mas[index] = value;
}
// найти элемент в массиве
void searchItem(int[] mas, int size, int value)
{
  bool isExist = false;
  Console.Write($"Число {value} встречается в следующих ячейках:");
  for(int i = 0; i < size; i++)
  {
    if(mas[i] == value)
    {
      Console.Write($" {i}");
      isExist = true;
    }
  }
  if(!isExist) Console.WriteLine(" не встречается :(");
}

// максимальная длина массива, можно менять на какую угодно
const int MAX_SIZE = 1000;


//
// основной код
//

// создание массива
int[] mas = new int[MAX_SIZE];

Console.Write($"Введите длину массива (макс. {MAX_SIZE}): ");
int size = int.Parse(Console.ReadLine());
Console.Write("Заполнить массив случайными данными? (y/n) ");
if(char.Parse(Console.ReadLine()) == 'y') fillArrayRandom(mas, size);
else fillArrayManual(mas, size);

// меню выбора, цикл разрывается на команде return
while(true)
{
  Console.Clear();
  Console.WriteLine("    --- Меню выбора действий ---");
  Console.WriteLine("\tp: Вывести весь массив");
  Console.WriteLine("\td: Удалить элемент из массива");
  Console.WriteLine("\ts: Поменять элементы массива местами");
  Console.WriteLine("\ta: Добавить элемент в массив");
  Console.WriteLine("\tr: Отсортировать массив");
  Console.WriteLine("\tf: Найти значение в массиве");
  Console.WriteLine("\tq: Выйти из программы");
  Console.Write("\n\tВаш выбор: ");
  char menu = char.Parse(Console.ReadLine());
  
  switch(menu)
  {
    case 'p':
        printArray(mas, size);
        Console.WriteLine("Нажмите Enter для возврата в меню");
        Console.ReadLine();
        break;

    case 'd':
        Console.Write($"Введите индекс элемента, который нужно удалить (0 - {size - 1}): ");
        int index = int.Parse(Console.ReadLine());
        if(index >= size)
        {
          Console.WriteLine("Индекс не существует.\nНажмите Enter для возврата в меню");
          Console.ReadLine();
          break;
        }
        removeItem(mas, size, index);
        size--;
        Console.WriteLine($"Элемент {index} был удален из массива. Размер массива уменьшен на 1.\nНажмите Enter для возврата в меню");
        Console.ReadLine();
        break;

    case 's':
        Console.Write($"Введите индекс первого элемента (0 - {size - 1}): ");
        int i1 = int.Parse(Console.ReadLine());
        Console.Write($"Введите индекс второго элемента (0 - {size - 1}): ");
        int i2 = int.Parse(Console.ReadLine());
        if(i1 >= size || i2 >= size)
        {
          Console.WriteLine("Один из введённых индексов не существует.\nНажмите Enter для возврата в меню");
          Console.ReadLine();
          break;
        }
        swapItems(mas, size, i1, i2);
        Console.WriteLine($"Элементы {i1} и {i2} были поменяны местами.\nНажмите Enter для возврата в меню");
        Console.ReadLine();
        break;

    case 'a':
        Console.Write("Введите число, которое хотите записать: ");
        int value = int.Parse(Console.ReadLine());
        Console.Write($"Введите индекс, куда записать это число (0 - {size - 1}): ");
        int i = int.Parse(Console.ReadLine());
        if(i > size)
        {
          Console.WriteLine("Индекс не существует.\nНажмите Enter для возврата в меню");
          Console.ReadLine();
          break;
        }
        size++;
        addItem(mas, size, value, i);
        Console.WriteLine("Элемент добавлен. Размер массива увеличен на 1.\nНажмите Enter для возврата в меню");
        Console.ReadLine();
        break;

    case 'r':
        // простой способ сортировки, но без использования функции
        Console.Write("Отсортировать в обратном порядке? (y/n) ");
        if(char.Parse(Console.ReadLine()) == 'y')
        {
          Array.Sort(mas, 0, size);
          Array.Reverse(mas, 0, size);
        }
        else Array.Sort(mas, 0, size);
        Console.WriteLine("Массив отсортирован.\nНажмите Enter для возврата в меню");
        Console.ReadLine();
        break;

    case 'f':
        Console.Write("Какое значение нужно найти: ");
        searchItem(mas, size, int.Parse(Console.ReadLine()));
        Console.WriteLine("\nНажмите Enter для возврата в меню");
        Console.ReadLine();
        break;

    case 'q':
        return;
    
    default:
        Console.WriteLine("Неверный выбор.\nНажмите Enter для возврата в меню");
        Console.ReadLine();
        break;
  }
}
