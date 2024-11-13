// public class TextureManager
// {
//     private Dictionary<string, Texture2D> textures;

//     public TextureManager(ContentManager content)
//     {
//         textures = new Dictionary<string, Texture2D>();
//         textures["EnemyTexture"] = content.Load<Texture2D>("path_to_enemy_texture");
//         textures["BlockTexture"] = content.Load<Texture2D>("path_to_block_texture");
//     }

//     public Texture2D GetTexture(string textureName)
//     {
//         return textures.ContainsKey(textureName) ? textures[textureName] : null;
//     }
// }
