# BigNumbers

Voi explica codul pas cu pas:

1.Clasa BigNumber are o metoda Main care este punctul de intrare al programului.

2.Metoda Main creeaza doua obiecte BigNumber, num1 si num2, si le atribuie valorile "12345" si "67890" respectiv.

3.Apoi, realizeaza diverse operatii aritmetice asupra acestor doua obiecte, cum ar fi adunarea, scaderea, inmultirea si impartirea si atribuie rezultatele la sum, difference, product, si quotient respectiv.

4.Rezultatele sunt apoi afisate in consola folosind metoda Console.WriteLine.

5.Clasa BigNumber mai are si un constructor care ia o șir de caractere ca intrare.

6.Constructorul creaza o lista noua numita number si apoi parcurge caracterele sirului de intrare, le converteste la numere intregi si le adauga la lista number.

7.Lista number este utilizată pentru a stoca cifrele numarului mare in ordine inversa.

8.Clasa mai are metode precum Add(), Subtract(), Multiply() si Divide() care efectueaza operatiile aritmetice corespunzatoare pe doua obiecte BigNumber.
9.Metoda Multiply() itereaza prin cifrele ambelor obiecte BigNumber si efectueaza inmultirea pentru fiecare pereche de cifre.

10.Metoda Divide() scade repetat divizorul din catul pana cand catul este mai mic decat divizorul.

11.Clasa mai are si alte metode precum CompareTo(), ToString() si Abs() care au rolul de a compara, a transforma in sir si de a lua valoarea absoluta a numarului, respectiv.
