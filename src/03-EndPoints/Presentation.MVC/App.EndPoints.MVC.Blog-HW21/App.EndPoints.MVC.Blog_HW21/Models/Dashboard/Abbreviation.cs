namespace App.EndPoints.MVC.Blog_HW21.Models.Dashboard
{
    public class Abbreviation
    {
        public static string GetInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return string.Empty;

            var parts = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
                return string.Empty;

            char firstInitial = parts[0][0];
            char lastInitial = parts[1][0];

            return $"{firstInitial}.{lastInitial}";
        }

    }
}
