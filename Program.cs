// В двумерном массиве целых чисел. Удалить строку и столбец, на пересечении которых расположен наименьший элемент.

Console.Clear();

Console.Write("Введите размер массива по Х: ");
int X = int.Parse(Console.ReadLine());
Console.Write("Введите размер массива по Y: ");
int Y = int.Parse(Console.ReadLine());

int[,] mass = new int[X, Y];
int[,] newmass = new int[X - 1, Y - 1];
Random rnd = new Random();
int MinX = 0;
int MinY = 0;

void MassFiller(int[,] array)
{
    for (int i = 0; i < X; i++)
    {
        for (int j = 0; j < Y; j++)
        {
            array[i, j] = rnd.Next(10, 100);
        }
    }
}

void MassPrint(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

MassFiller(mass);
MassPrint(mass);

int min = mass[0, 0];
for (int i = 0; i < X; i++)
{
    for (int j = 0; j < Y; j++)
    {
        if (mass[i, j] < min)
        {
            MinX = i;
            MinY = j;
            min = mass[i, j];
        }
    }
}

Console.WriteLine(min + ":\t" + MinX + "\t" + MinY);
Console.WriteLine();

for (int i = 0; i < X; i++)
{
    for (int j = 0; j < Y; j++)
    {
        if (i != MinX && j != MinY)
        {
            if (i < MinX && j < MinY) newmass[i, j] = mass[i, j];
            else if (i < MinX && j > MinY) newmass[i, j - 1] = mass[i, j];
            else if (i > MinX && j < MinY) newmass[i - 1, j] = mass[i, j];
            else if (i > MinX && j > MinY) newmass[i - 1, j - 1] = mass[i, j];            
        }
    }
}

MassPrint(newmass);