interface IslemTip
{
    int Islem(int a, int c);
}

class Topla : IslemTip
{
    public int Islem(int a, int b)
    {
        return a + b;
    }
}

class Cikart : IslemTip
{
    public int Islem(int a, int b)
    {
        return a - b;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Func<int, int, IslemTip, int> f =
             (a, b, t) => t.Islem(a, b);

        Console.WriteLine(f(3, 4, new Topla()));
        Console.WriteLine(f(3, 4, new Cikart()));
    }
}

delegate int IslemTipHandler(int a, int b, IslemTip islem);

static int DelegateCalistir(int a, int b, IslemTip islem)
{
    return islem.Islem(a, b);
}

static void Main(string[] args)
{
    IslemTipHandler ith = new IslemTipHandler(DelegateCalistir);
    Console.WriteLine(ith.Invoke(3, 4, new Topla()));
    Console.WriteLine(ith.Invoke(3, 4, new Cikart()));
}


abstract class IslemTip
{
    public abstract int Islem(int a, int b);

    public static IslemTip Olustur(string s)
    {
        if (s == "Topla") return new Topla();
        else if (s == "Cikart") return new Cikart();
        return null;
    }
}

class Topla : IslemTip
{

    public override int Islem(int a, int b)
    {
        return a + b;
    }
}

class Cikart : IslemTip
{
    public override int Islem(int a, int b)
    {
        return a - b;
    }
}

class Program
{

    static void Main(string[] args)
    {
        Func<int, int, string, int> f =
              (a, b, t) => IslemTip.Olustur(t).Islem(a, b);

        Console.WriteLine(f(3, 4, "Topla"));
        Console.WriteLine(f(3, 4, "Cikart"));
    }
}

