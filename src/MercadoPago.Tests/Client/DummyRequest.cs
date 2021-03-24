namespace MercadoPago.Tests.Client
{
    /// <summary>
    /// Dummy request for tests.
    /// </summary>
    public class DummyRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyRequest"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        public DummyRequest(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DummyRequest"/> class.
        /// </summary>
        public DummyRequest()
        {
        }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }
    }
}
