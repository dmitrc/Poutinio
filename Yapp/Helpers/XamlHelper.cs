using Windows.UI.Xaml;

namespace Yapp.Helpers
{
    public static class X
    {
        public static bool Not(bool b)
        {
            return !b;
        }

        public static Visibility ShowIf(bool b)
        {
            return b ? Visibility.Visible : Visibility.Collapsed;
        }

        public static Visibility ShowIfNot(bool b)
        {
            return ShowIf(Not(b));
        }

        public static bool If(string s)
        {
            return !string.IsNullOrEmpty(s);
        }

        public static bool IfNot(string s)
        {
            return Not(If(s));
        }

        public static Visibility ShowIf(string s)
        {
            return ShowIf(If(s));
        }

        public static Visibility ShowIfNot(string s)
        {
            return ShowIfNot(If(s));
        }
    }
}
