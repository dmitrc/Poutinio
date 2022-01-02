using System.Collections;
using Windows.UI.Xaml;

namespace Poutinio.Helpers
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

        public static bool If(ICollection c)
        {
            return (c?.Count ?? 0) > 0;
        }

        public static bool IfNot(string s)
        {
            return Not(If(s));
        }

        public static bool IfNot(ICollection c)
        {
            return Not(If(c));
        }

        public static Visibility ShowIf(string s)
        {
            return ShowIf(If(s));
        }

        public static Visibility ShowIfNot(string s)
        {
            return ShowIfNot(If(s));
        }

        public static Visibility ShowIf(ICollection c)
        {
            return ShowIf(If(c));
        }

        public static Visibility ShowIfNot(ICollection c)
        {
            return ShowIfNot(If(c));
        }

        public static string GetFileIcon(string type)
        {
            if (type == "FOLDER")
            {
                return "\uE8B7";
            }
            else if (type == "AUDIO")
            {
                return "\uE8D6";
            }
            else if (type == "VIDEO")
            {
                return "\uE768";
            }
            else if (type == "IMAGE")
            {
                return "\uE722";
            }
            else if (type == "ARCHIVE")
            {
                return "\uE8F1";
            }
            else // FILE, SWF, PDF, TEXT
            {
                return "\uE7C3";
            }
        }

        public static string Format(string s, object arg1)
        {
            return string.Format(s, arg1);
        }

        public static string Format(string s, object arg1, object arg2)
        {
            return string.Format(s, arg1, arg2);
        }

        public static string Format(string s, object arg1, object arg2, object arg3)
        {
            return string.Format(s, arg1, arg2, arg3);
        }
    }
}
