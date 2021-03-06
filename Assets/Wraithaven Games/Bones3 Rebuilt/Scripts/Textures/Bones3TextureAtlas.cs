using Bones3Rebuilt;

using UnityEngine;

#pragma warning disable 649

namespace WraithavenGames.Bones3
{
    /// <summary>
    /// The main container for a texture atlas object.
    /// </summary>
    [AddComponentMenu("Bones3/Texture Atlas"), ExecuteAlways]
    public class Bones3TextureAtlas : MonoBehaviour, ITextureAtlas
    {
        #region Inspector
        [Tooltip("The texture array to apply to blocks using this texture atlas.")]
        [SerializeField] private Material m_Material;
        #endregion

        /// <summary>
        /// Gets the material represented by this texture atlas.
        /// </summary>
        public Material Material => m_Material;

        #region Object Wrapper
        private ITextureAtlas m_TextureAtlas;

        /// <summary>
        /// The texture atlas currently maintained by this behaviour.
        /// </summary>
        /// <value>The raw texture atlas.</value>
        public ITextureAtlas RawAtlas
        {
            get
            {
                if (m_TextureAtlas == null)
                    OnEnable();

                return m_TextureAtlas;
            }
            private set => m_TextureAtlas = value;
        }

        /// <summary>
        /// Called when the texture atlas behaviour is enabled.
        /// </summary>
        void OnEnable()
        {
            if (m_TextureAtlas != null)
                return;

            m_TextureAtlas = new TextureAtlas();

            // TODO Serialize texture data and remove this temp data

            AddTexture(); // Grass
            AddTexture(); // Side Dirt
            AddTexture(); // Dirt
        }

        /// <summary>
        /// Called when the texture atlas behaviour is disabled.
        /// </summary>
        void OnDisable()
        {
            if (m_TextureAtlas == null)
                return;

            m_TextureAtlas = null;
        }
        #endregion

        #region Object API
        /// <inheritdoc cref="ITextureAtlas"/>
        public int Count => RawAtlas.Count;

        /// <inheritdoc cref="ITextureAtlas"/>
        public IBlockTexture AddTexture() => RawAtlas.AddTexture();

        /// <inheritdoc cref="ITextureAtlas"/>
        public IBlockTexture GetTexture(int index) => RawAtlas.GetTexture(index);
        #endregion
    }
}
