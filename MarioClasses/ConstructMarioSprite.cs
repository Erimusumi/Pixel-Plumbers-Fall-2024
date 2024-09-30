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
                                game.CurrentMarioSprite = new SmallIdleLeftMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigIdleLeftMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireIdleLeftMario(game.MarioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Run:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallRunLeftMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigRunLeftMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireRunLeftMario(game.MarioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Swim:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallSwimLeftMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigSwimLeftMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireSwimLeftMario(game.MarioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Turning:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallTurningLeftMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigTurningLeftMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireTurningLeftMario(game.MarioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Crouch:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallIdleLeftMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigCrouchLeftMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireCrouchLeftMario(game.MarioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Jump:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallJumpLeftMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigJumpLeftMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireJumpLeftMario(game.MarioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Dead:
                        game.CurrentMarioSprite = new DeadMario(game.MarioTexture);
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
                                game.CurrentMarioSprite = new SmallIdleRightMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigIdleRightMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireIdleRightMario(game.MarioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Run:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallRunRightMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigRunRightMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireRunRightMario(game.MarioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Swim:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallSwimRightMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigSwimRightMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireSwimRightMario(game.MarioTexture);
                                break;
                        }
                        break;
                    case MarioState.MarioStateEnum.Turning:
                        switch (marioState.GetPowerup())
                        {
                            case MarioState.MarioPowerupEnum.Base:
                                game.CurrentMarioSprite = new SmallTurningRightMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Big:
                                game.CurrentMarioSprite = new BigTurningRightMario(game.MarioTexture);
                                break;
                            case MarioState.MarioPowerupEnum.Fire:
                                game.CurrentMarioSprite = new FireTurningRightMario(game.MarioTexture);
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
