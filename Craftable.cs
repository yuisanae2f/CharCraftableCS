namespace yuisanae2f.CharCraftableCS
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">T must be either <see cref="char"/> or <see cref="string"/>.</typeparam>
    public interface Craftable<T>
    {
        /// <summary>
        /// The shredded string which display the compose of <see cref="value"/>
        /// </summary>
        public string shredded { get; set; }

        /// <summary>
        /// The raw value craftable given.
        /// </summary>
        public T value { get; set; }
    }
}

// © 2023. YuiSanae2f