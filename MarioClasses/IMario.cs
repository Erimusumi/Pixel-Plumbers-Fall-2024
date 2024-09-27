using Pixel_Plumbers_Fall_2024;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMario
{
    void TakeDamage();
    void Update();
    void Jump();
    void Stop();
    void Run();
    void Swim();
    void SwapDir();
    void Turning();
    void CollectPowerup(int powType);
    void CollectStar();
    void Crouch();

}




  




