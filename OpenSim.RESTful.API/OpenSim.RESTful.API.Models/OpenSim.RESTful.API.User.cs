namespace OpenSim.RESTful.API.Models
{
    public class User
    {
        /// <summary>
        /// The first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The user's unique identifier (UUID).
        /// </summary>
        public string UUID { get; set; }

        /// <summary>
        /// The email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The user's hashed password (optional for API).
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The user's account type or model (e.g., default avatar template).
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// The user's account level (e.g., admin, standard user).
        /// </summary>
        public int UserLevel { get; set; }

        /// <summary>
        /// Timestamp when the account was created.
        /// </summary>
        public System.DateTime CreatedAt { get; set; }
    }
}
