using System.Runtime.Serialization;

namespace CvApp.Models
{
    public class Resume
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string DateOfBirth { get; set; }

        public string Email { get; set; }

        public string LinkedIn { get; set; }

        public Education[] Education { get; set; }
    }
}
