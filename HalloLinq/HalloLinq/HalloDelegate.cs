namespace HalloLinq
{
    delegate void EinfacherDelegate();
    delegate void DelegateMitParameter(string text);
    delegate long CalcDelegate(int a, int b);

    internal class HalloDelegate
    {
        public HalloDelegate()
        {
            EinfacherDelegate einfacherDelegate = EinfacheMethode;
            Action action = EinfacheMethode;
            Action actionAnon = delegate () { Console.WriteLine("Hallo"); };
            Action actionAnon2 = () => { Console.WriteLine("Hallo"); };
            Action actionAnon3 = () => Console.WriteLine("Hallo");

            DelegateMitParameter methodeMitPara = MethodeMitParameter;
            Action<string> actionMitPara = MethodeMitParameter;
            Action<string> actionMitParaAnon = delegate (string text) { Console.WriteLine(text); };
            Action<string> actionMitParaAnon2 = (string text) => { Console.WriteLine(text); };
            Action<string> actionMitParaAnon3 = (text) => Console.WriteLine(text);
            Action<string> actionMitParaAnon4 = x => Console.WriteLine(x);

            CalcDelegate calc = Minus;
            Func<int, int, long> calcFunc = Add;
            Func<int, int, long> calcFuncAnon = delegate (int a, int b) { return a + b; };
            Func<int, int, long> calcFuncAnon2 = (int a, int b) => { return a + b; };
            Func<int, int, long> calcFuncAnon3 = (a, b) => { return a + b; };
            Func<int, int, long> calcFuncAnon4 = (a, b) => a + b;

            List<string> texte = new();

            texte.Where(x => x.StartsWith("b"));
            texte.Where(Filter);

        }

        private bool Filter(string arg)
        {
            if (arg.StartsWith("b"))
                return true;
            else
                return false;
        }

        private long Minus(int a, int b)
        {
            return a - b;
        }

        private long Add(int a, int b)
        {
            return a + b;
        }

        void EinfacheMethode()
        {
            Console.WriteLine("Hallo");
        }

        void MethodeMitParameter(string msg)
        {
            Console.WriteLine($"Hallo {msg}");
        }
    }
}
