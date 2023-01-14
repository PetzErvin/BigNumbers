using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

class BigNumber
{
    static void Main(string[] args)
    {
        BigNumber num1 = new BigNumber("12345");
        BigNumber num2 = new BigNumber("67890");

        // solutie aritmetica
        BigNumber sum = num1.Add(num2);
        BigNumber difference = num1.Subtract(num2);
        BigNumber product = num1.Multiply(num2);
        BigNumber quotient = num1.Divide(num2);

        //afiseaza rezultatele 
        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Difference: " + difference);
        Console.WriteLine("Product: " + product);
        Console.WriteLine("Quotient: " + quotient);

        Console.ReadLine();
    }
    private List<int> number;

    public BigNumber(string num)
    {
        number = new List<int>();

        for (int i = num.Length - 1; i >= 0; i--)
            number.Add(num[i] - '0');
    }

    //Adunarea a doua numere mari
    public BigNumber Add(BigNumber b)
    {
        BigNumber result = new BigNumber("");
        int carry = 0;

        for (int i = 0; i < Math.Max(this.number.Count, b.number.Count); i++)
        {
            int a = (i < this.number.Count) ? this.number[i] : 0;
            var c = (i < b.number.Count) ? b.number[i] : 0;

            int s = a + c + carry;
            result.number.Add(s % 10);
            carry = s / 10;
        }

        if (carry != 0)
            result.number.Add(carry);

        return result;
    }

    //Scaderea a doua numere mari
    public BigNumber Subtract(BigNumber b)
    {
        BigNumber result = new BigNumber("");

        int borrow = 0;

        for (int i = 0; i < this.number.Count; i++)
        {
            int a = this.number[i];
            var c = (i < b.number.Count) ? b.number[i] : 0;

            int s = a - c - borrow;

            if (s < 0)
            {
                s += 10;
                borrow = 1;
            }
            else
                borrow = 0;

            result.number.Add(s);
        }

        while (result.number.Count > 1 && result.number[result.number.Count - 1] == 0)
            result.number.RemoveAt(result.number.Count - 1);

        return result;
    }

    //Inmultirea a doua numere mari
    public BigNumber Multiply(BigNumber b)
    {
        BigNumber result = new BigNumber("");
        result.number.Add(0);

        for (int i = 0; i < this.number.Count; i++)
        {
            int carry = 0;

            for (int j = 0; j < b.number.Count; j++)
            {
                int index = i + j;
                if (index >= result.number.Count)
                    result.number.Add(0);

                int prod = this.number[i] * b.number[j] + result.number[index] + carry;

                result.number[index] = prod % 10;
                carry = prod / 10;
            }

            int k = i + b.number.Count;
            while (carry != 0)
            {
                if (k >= result.number.Count)
                    result.number.Add(carry);
                else
                    result.number[k] += carry;

                carry /= 10;
                k++;
            }

        }

        return result;
    }

    //Impartirea a doua numere mari
    public BigNumber Divide(BigNumber b)
    {
        BigNumber quotient = new BigNumber(""); quotient.number.Add(0);
        BigNumber dividend = new BigNumber(this.ToString());
        BigNumber divisor = new BigNumber(b.ToString());

        while (dividend.CompareTo(divisor) >= 0)
        {
            BigNumber temp = new BigNumber(divisor.ToString());
            int quot = 0;

            while (dividend.CompareTo(temp) >= 0)
            {
                temp = temp.Multiply(new BigNumber("2"));
                quot++;
            }

            quotient = quotient.Add(new BigNumber(Math.Pow(2, quot - 1).ToString()));
            dividend = dividend.Subtract(divisor.Multiply(new BigNumber(Math.Pow(2, quot - 1).ToString())));
            divisor = divisor.Multiply(new BigNumber("2"));
        }

        return quotient;
    }

    //Ridicarea la putere a unui numar mare
    public BigNumber Power(int pow)
    {
        BigNumber result = new BigNumber("1");
        BigNumber baseNum = new BigNumber(this.ToString());

        for (int i = 0; i < pow; i++)
            result = result.Multiply(baseNum);

        return result;
    }

    public override string ToString()
    {
        string num = "";

        for (int i = number.Count - 1; i >= 0; i--)
            num += number[i];

        return num;
    }
    public int CompareTo(BigNumber other)
    {
        if (this.number.Count > other.number.Count)
            return 1;
        else if (this.number.Count < other.number.Count)
            return -1;
        else
        {
            for (int i = this.number.Count - 1; i >= 0; i--)
            {
                if (this.number[i] > other.number[i])
                    return 1;
                else if (this.number[i] < other.number[i])
                    return -1;
            }
            return 0;
        }
       
    }

    private BigNumber Sqrt()
    {
        BigNumber x = new BigNumber(this.ToString());
        BigNumber y = new BigNumber("1");
        BigNumber epsilon = new BigNumber("0.0001");
        BigNumber temp;

        while (x.Subtract(y).Abs().CompareTo(epsilon) > 0)
        {
            temp = y;
            y = x.Add(y.Divide(y)).Divide(new BigNumber("2"));
            x = temp;
        }

        return y;
    }
    public BigNumber Abs()
    {
        BigNumber result = new BigNumber(this.ToString());
        if (result.number[result.number.Count - 1] < 0)
        {
            for (int i = 0; i < result.number.Count; i++)
            {
                result.number[i] = -result.number[i];
            }
        }
        return result;
    }
}

//voi explica codul pas cu pas:
//Clasa BigNumber are o metoda Main care este punctul de intrare al programului.
//Metoda Main creeaza doua obiecte BigNumber, num1 si num2, si le atribuie valorile "12345" si "67890" respectiv.
//Apoi, realizeaza diverse operatii aritmetice asupra acestor doua obiecte, cum ar fi adunarea, scaderea, inmultirea si impartirea si atribuie rezultatele la sum, difference, product, si quotient respectiv.
//Rezultatele sunt apoi afisate in consola folosind metoda Console.WriteLine.
//Clasa BigNumber mai are si un constructor care ia o șir de caractere ca intrare.
//Constructorul creaza o lista noua numita number si apoi parcurge caracterele sirului de intrare, le converteste la numere intregi si le adauga la lista number.cifrele numarului mare in ordine inversa.
//Clasa mai are metode precum Add(), Subtract(), Multiply() si Divide() care efectueaza operatiile aritmetice corespunzatoare pe doua obiecte BigNumber.
//Metoda Multiply() itereaza prin cifrele ambelor obiecte BigNumber si efectueaza inmultirea pentru fiecare pereche de cifre.
//Metoda Divide() scade repetat divizorul din catul pana cand catul este mai mic decat divizorul
//Clasa mai are si alte metode precum CompareTo(), ToString() si Abs() care au rolul de a compara, a transforma in sir si de a lua valoarea absoluta a numarului, respectiv.






