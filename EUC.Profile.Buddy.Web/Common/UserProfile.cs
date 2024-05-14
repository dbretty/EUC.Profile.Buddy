namespace EUC.Profile.Buddy.Web.Common
{
    public class UserProfile
    {

        public int TotalProfiles(List<Repositories.Entities.UserProfileSummary> profiles)
        {
            var i = 0;
            foreach (var profile in profiles)
            {
                i++;
            }
            return i;
        }

        public long TotalProfileSize(List<Repositories.Entities.UserProfileSummary> profiles)
        {
            var size = 0L;
            foreach (var profile in profiles)
            {
                size = size + profile.ProfileSize;
            }
            return size;
        }
    }
}
