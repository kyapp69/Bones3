namespace Bones3Rebuilt
{
    /// <summary>
    /// A task which was executed to generate a single mesh layer of a chunk
    /// based on the given properties of that chunk.
    /// </summary>
    public interface IRemeshTask
    {
        /// <summary>
        /// Gets the mesh which was generated by this task.
        /// </summary>
        /// <value>The mesh.</value>
        ProcMesh Mesh { get; }

        /// <summary>
        /// Waits for this task to finish executing before continuing.
        /// </summary>
        void Finish();
    }
}