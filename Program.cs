using System;

class Program
{
    static void Main(string[] args)
    {
        // 1110410034 柯向澄
        Console.Write("請輸入圓半徑(可包含小數點): ");
        double radius;

        // 判斷使用者輸入是否為數字
        if (!double.TryParse(Console.ReadLine(), out radius))
        {
            Console.WriteLine("圓半徑輸入錯誤，請重新輸入。");
            return;
        }

        Console.Write("請輸入圓週率精度(4 <= n <= 15): ");
        int n;
        // 如果使用者輸入是否為數字
        if (!int.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("圓週率精度輸入錯誤，請重新輸入。");
            return;
        }

        // 計算圓週率
        double pi = CountPi(n);

        // 如果CountPi(n)回傳-1，代表範圍錯誤，直接結束主程式。
        if (pi == -1)
        {
            return;
        }

        // 計算圓周長
        double circumference = GetCircumference(radius, n);
        // 計算圓面積
        double area = GetCircleArea(radius, n);

        // 顯示結果
        Console.WriteLine("您所輸入精度為: {0}", n);
        Console.WriteLine("該圓的圓週率為: {0:g}", pi);
        Console.WriteLine("該圓的圓周長為: {0:g}", circumference);
        Console.WriteLine("該圓的圓面積為: {0:g}", area);
    }

    static double CountPi(int n)
    {
        // 當 n 不在範圍內時回傳 -1
        if (n < 4 || n > 15)
        {
            return -1;
        }

        // 計算圓週率
        double sum = 0.0;
        for (int i = 0; i < n; i++)
        {
            double term = 1.0 / (2 * i + 1);
            if (i % 2 == 0)
            {
                sum += term;  // even
            }
            else
            {
                sum -= term;  // odd
            }
        }

        double pi = 4 * sum;
        return pi;
    }

    static double GetCircumference(double r, int n)
    {
        double pi = CountPi(n);

        return 2 * pi * r;
    }

    static double GetCircleArea(double r, int n)
    {
        double pi = CountPi(n);

        return pi * r * r;
    }
}
