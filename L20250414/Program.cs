namespace L20250414
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> st = new();

            st.Push(1);
            st.Push(2);
            st.Push(3);

            st.Peek();

            int num = st.Pop();
            num = st.Pop();
            num = st.Pop();
        }
    }
}
