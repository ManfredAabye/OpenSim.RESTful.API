namespace OpenSim.RESTful.API.Models
{
    public class Asset
    {
        /// <summary>
        /// The unique identifier of the asset.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// The name of the asset.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of the asset (e.g., texture, sound, object).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Size of the asset in bytes.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// The timestamp when the asset was created or last modified.
        /// </summary>
        public System.DateTime Timestamp { get; set; }
    }
}
