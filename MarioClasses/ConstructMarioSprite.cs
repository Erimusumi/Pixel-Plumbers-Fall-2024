using Pixel_Plumbers_Fall_2024;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Plumbers_Fall_2024;

public class MarioSpriteConstructor
{
    public static void ConstructMarioSprite(MarioState marioState, Game1 game)
    {
        switch (marioState.GetDirection())
        {
            case MarioState.MarioDirectionEnum.Left:
                switch (marioState.GetState())
                {
                    case MarioState.MarioStateEnum.Still:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallIdleLeftMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigIdleLeftMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireIdleLeftMario(game.marioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Run:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallRunLeftMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigRunLeftMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireRunLeftMario(game.marioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Swim:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallSwimLeftMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigSwimLeftMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireSwimLeftMario(game.marioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Turning:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallTurningLeftMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigTurningLeftMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireTurningLeftMario(game.marioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Crouch:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallIdleLeftMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigCrouchLeftMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireCrouchLeftMario(game.marioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Jump:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallJumpLeftMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigJumpLeftMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireJumpLeftMario(game.marioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Dead:
                        game.CurrentMarioSprite = new DeadMario(game.marioTexture);
                        break;
                }
                break;
            case MarioState.MarioDirectionEnum.Right:
                switch (marioState.GetState())
                {
                    case MarioState.MarioStateEnum.Still:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallIdleRightMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigIdleRightMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireIdleRightMario(game.marioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Run:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallRunRightMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigRunRightMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireRunRightMario(game.marioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Swim:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallSwimRightMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigSwimRightMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireSwimRightMario(game.marioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Turning:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallTurningRightMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigTurningRightMario(game.marioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireTurningRightMario(game.marioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Crouch:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallIdleRightMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigCrouchRightMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireCrouchRightMario(game.MarioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Jump:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallJumpRightMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigJumpRightMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireJumpRightMario(game.MarioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Dead:
                        game.CurrentMarioSprite = new DeadMario(game.MarioTexture);
                        break;
                }
                break;
        }
    }
}
