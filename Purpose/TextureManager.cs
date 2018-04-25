using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Purpose
{
    public class TextureManager
    {
        //fields
        #region Player and Enemy Textures
        private Texture2D rightStandingSprite;
        private Texture2D leftStandingSprite;
        private Texture2D rightMiddleRunningSprite;
        private Texture2D leftMiddleRunningSprite;
        private Texture2D rightRunningSprite;
        private Texture2D leftRunningSprite;
        private Texture2D rightJumpSprite;
        private Texture2D leftJumpSprite;
        private Texture2D rightPlayerAttack1;
        private Texture2D leftPlayerAttack1;
        private Texture2D rightPlayerAttack2;
        private Texture2D leftPlayerAttack2;
        private Texture2D rightEnemyWalk1;
        private Texture2D rightEnemyWalk2;
        private Texture2D rightEnemyWalk3;
        private Texture2D leftEnemyWalk1;
        private Texture2D leftEnemyWalk2;
        private Texture2D leftEnemyWalk3;
        private Texture2D rangedEnemyTexture;
        #endregion

        #region Sombrero Textures
        private Texture2D sombreroRangedEnemy;
        private Texture2D rightSombreroMelee1;
        private Texture2D rightSombreroMelee2;
        private Texture2D rightSombreroMelee3;
        private Texture2D leftSombreroMelee1;
        private Texture2D leftSombreroMelee2;
        private Texture2D leftSombreroMelee3;
        #endregion

        #region Ushanka Textures
        private Texture2D ushankaRangedEnemy;
        private Texture2D rightUshankaMelee1;
        private Texture2D rightUshankaMelee2;
        private Texture2D rightUshankaMelee3;
        private Texture2D leftUshankaMelee1;
        private Texture2D leftUshankaMelee2;
        private Texture2D leftUshankaMelee3;
        #endregion

        #region Fez Textures
        private Texture2D fezRangedEnemy;
        private Texture2D rightFezMelee1;
        private Texture2D rightFezMelee2;
        private Texture2D rightFezMelee3;
        private Texture2D leftFezMelee1;
        private Texture2D leftFezMelee2;
        private Texture2D leftFezMelee3;
        #endregion

        #region Cowboy Textures
        private Texture2D cowboyRangedEnemy;
        private Texture2D rightCowboyMelee1;
        private Texture2D rightCowboyMelee2;
        private Texture2D rightCowboyMelee3;
        private Texture2D leftCowboyMelee1;
        private Texture2D leftCowboyMelee2;
        private Texture2D leftCowboyMelee3;
        #endregion

        #region Beret Textures
        private Texture2D beretRangedEnemy;
        private Texture2D rightBeretMelee1;
        private Texture2D rightBeretMelee2;
        private Texture2D rightBeretMelee3;
        private Texture2D leftBeretMelee1;
        private Texture2D leftBeretMelee2;
        private Texture2D leftBeretMelee3;
        #endregion

        private Texture2D startScreen;
        private Texture2D buttonFrame;
        private Texture2D roundedFrame;
        private Texture2D upgradeScreen;
        private Texture2D pauseScreen;
        private Texture2D nextWaveScreen;
        private Texture2D gameOver;
        private Texture2D youWin;
        private Texture2D controlScreen;
        private Texture2D unlockablesUI;

        private Texture2D basePlatform;
        private Texture2D notBasePlatform;

        private Texture2D metalBack;

        private Texture2D healthbar;
        private Texture2D staminabar;

        private Texture2D groundPoundTip;
        private Texture2D damageUpTip;
        private Texture2D staminaUpTip;
        private Texture2D healthUpTip;
        private Texture2D dashTip;
        private Texture2D dashUpTip;

        //sprite properties
        #region Player and Enemy Properties
        public Texture2D RightStandingSprite { get { return rightStandingSprite; } }
        public Texture2D LeftStandingSprite { get { return leftStandingSprite; } }
        public Texture2D RightMiddleRunningSprite { get { return rightMiddleRunningSprite; } }
        public Texture2D LeftMiddleRunningSprite { get { return leftMiddleRunningSprite; } }
        public Texture2D RightRunningSprite { get { return rightRunningSprite; } }
        public Texture2D LeftRunningSprite { get { return leftRunningSprite; } }
        public Texture2D RightJumpSprite { get { return rightJumpSprite; } }
        public Texture2D LeftJumpSprite { get { return leftJumpSprite; } }
        public Texture2D RightPlayerAttack1 { get { return rightPlayerAttack1; } }
        public Texture2D LeftPlayerAttack1 { get { return leftPlayerAttack1; } }
        public Texture2D RightPlayerAttack2 { get { return rightPlayerAttack2; } }
        public Texture2D LeftPlayerAttack2 { get { return leftPlayerAttack2; } }
        public Texture2D RightEnemyWalk1 { get { return rightEnemyWalk1; } }
        public Texture2D RightEnemyWalk2 { get { return rightEnemyWalk2; } }
        public Texture2D RightEnemyWalk3 { get { return rightEnemyWalk3; } }
        public Texture2D LeftEnemyWalk1 { get { return leftEnemyWalk1; } }
        public Texture2D LeftEnemyWalk2 { get { return leftEnemyWalk2; } }
        public Texture2D LeftEnemyWalk3 { get { return leftEnemyWalk3; } }
        public Texture2D RangedEnemyTexture
        {
            get { return rangedEnemyTexture; }
            set { rangedEnemyTexture = value; }
        }
        #endregion

        #region Sombrero Properties
        public Texture2D SombreroRangedEnemy { get { return sombreroRangedEnemy; } }
        public Texture2D RightSombreroMelee1 { get { return rightSombreroMelee1; } }
        public Texture2D RightSombreroMelee2 { get { return rightSombreroMelee2; } }
        public Texture2D RightSombreroMelee3 { get { return rightSombreroMelee3; } }
        public Texture2D LeftSombreroMelee1 { get { return leftSombreroMelee1; } }
        public Texture2D LeftSombreroMelee2 { get { return leftSombreroMelee2; } }
        public Texture2D LeftSombreroMelee3 { get { return leftSombreroMelee3; } }
        #endregion

        #region Ushanka Properties
        public Texture2D UshankaRangedEnemy { get { return ushankaRangedEnemy; } }
        public Texture2D RightUshankaMelee1 { get { return rightUshankaMelee1; } }
        public Texture2D RightUshankaMelee2 { get { return rightUshankaMelee2; } }
        public Texture2D RightUshankaMelee3 { get { return rightUshankaMelee3; } }
        public Texture2D LeftUshankaMelee1 { get { return leftUshankaMelee1; } }
        public Texture2D LeftUshankaMelee2 { get { return leftUshankaMelee2; } }
        public Texture2D LeftUshankaMelee3 { get { return leftUshankaMelee3; } }
        #endregion

        #region Fez Properties
        public Texture2D FezRangedEnemy { get { return fezRangedEnemy; } }
        public Texture2D RightFezMelee1 { get { return rightFezMelee1; } }
        public Texture2D RightFezMelee2 { get { return rightFezMelee2; } }
        public Texture2D RightFezMelee3 { get { return rightFezMelee3; } }
        public Texture2D LeftFezMelee1 { get { return leftFezMelee1; } }
        public Texture2D LeftFezMelee2 { get { return leftFezMelee2; } }
        public Texture2D LeftFezMelee3 { get { return leftFezMelee3; } }
        #endregion

        #region Cowboy Properties
        public Texture2D CowboyRangedEnemy { get { return cowboyRangedEnemy; } }
        public Texture2D RightCowboyMelee1 { get { return rightCowboyMelee1; } }
        public Texture2D RightCowboyMelee2 { get { return rightCowboyMelee2; } }
        public Texture2D RightCowboyMelee3 { get { return rightCowboyMelee3; } }
        public Texture2D LeftCowboyMelee1 { get { return leftCowboyMelee1; } }
        public Texture2D LeftCowboyMelee2 { get { return leftCowboyMelee2; } }
        public Texture2D LeftCowboyMelee3 { get { return leftCowboyMelee3; } }
        #endregion

        #region Beret Properties
        public Texture2D BeretRangedEnemy { get { return beretRangedEnemy; } }
        public Texture2D RightBeretMelee1 { get { return rightBeretMelee1; } }
        public Texture2D RightBeretMelee2 { get { return rightBeretMelee2; } }
        public Texture2D RightBeretMelee3 { get { return rightBeretMelee3; } }
        public Texture2D LeftBeretMelee1 { get { return leftBeretMelee1; } }
        public Texture2D LeftBeretMelee2 { get { return leftBeretMelee2; } }
        public Texture2D LeftBeretMelee3 { get { return leftBeretMelee3; } }
        #endregion

        public Texture2D MetalBack { get { return metalBack; } }

        public Texture2D StartScreen { get { return startScreen; } }
        public Texture2D ButtonFrame { get { return buttonFrame; } }
        public Texture2D RoundedFrame { get { return roundedFrame; } }
        public Texture2D UpgradeScreen { get { return upgradeScreen; } }
        public Texture2D PauseScreen { get { return pauseScreen; } }
        public Texture2D NextWaveScreen { get { return nextWaveScreen; } }
        public Texture2D GameOver { get { return gameOver; } }
        public Texture2D YouWin { get { return youWin; } }
        public Texture2D ControlScreen { get { return controlScreen; } }

        public Texture2D BasePlatform { get { return basePlatform; } }
        public Texture2D NotBasePlatform { get { return notBasePlatform; } }

        public Texture2D Staminabar { get { return staminabar; } }
        public Texture2D Healthbar { get { return healthbar; } }

        public Texture2D GroundPoundTip { get { return groundPoundTip; } }
        public Texture2D DamageUpTip { get { return damageUpTip; } }
        public Texture2D StaminaUpTip { get { return staminaUpTip; } }
        public Texture2D HealthUpTip { get { return healthUpTip; } }
        public Texture2D DashTip { get { return dashTip; } }
        public Texture2D DashUpTip { get { return dashUpTip; } }

        public Texture2D UnlockablesUI { get { return unlockablesUI; } }

        //constructor
        public TextureManager(Texture2D leftStandingSprite, Texture2D rightStandingSprite, Texture2D leftMiddleRunningSprite, Texture2D rightMiddleRunningSprite,
            Texture2D leftRunningSprite, Texture2D rightRunningSprite, Texture2D rightPlayerAttack1, Texture2D leftPlayerAttack1, Texture2D rightPlayerAttack2, Texture2D leftPlayerAttack2,
            Texture2D rightEnemyWalk1, Texture2D rightEnemyWalk2, Texture2D rightEnemyWalk3, Texture2D leftEnemyWalk1, Texture2D leftEnemyWalk2, Texture2D leftEnemyWalk3,
            Texture2D rangedEnemyTexture, Texture2D startScreen, Texture2D buttonFrame, Texture2D roundedFrame,
            Texture2D upgradeScreen, Texture2D pauseScreen, Texture2D nextWaveScreen, Texture2D gameOver, Texture2D youWin, Texture2D controlScreen, Texture2D basePlatform, Texture2D notBasePlatform, Texture2D metalBack,
            Texture2D staminabar, Texture2D healthbar, Texture2D groundPoundTip, Texture2D damageUpTip, Texture2D staminaUpTip, Texture2D healthUpTip, Texture2D dashTip, Texture2D dashUpTip, Texture2D unlockablesUI,
            Texture2D sombreroRangedEnemy, Texture2D rightSombreroMelee1, Texture2D rightSombreroMelee2, Texture2D rightSombreroMelee3, Texture2D leftSombreroMelee1, Texture2D leftSombreroMelee2, Texture2D leftSombreroMelee3,
            Texture2D ushankaRangedEnemy, Texture2D rightUshankaMelee1, Texture2D rightUshankaMelee2, Texture2D rightUshankaMelee3, Texture2D leftUshankaMelee1, Texture2D leftUshankaMelee2, Texture2D leftUshankaMelee3,
            Texture2D fezRangedEnemy, Texture2D rightFezMelee1, Texture2D rightFezMelee2, Texture2D rightFezMelee3, Texture2D leftFezMelee1, Texture2D leftFezMelee2, Texture2D leftFezMelee3)
        {
            this.rightStandingSprite = rightStandingSprite;
            this.leftStandingSprite = leftStandingSprite;
            this.rightMiddleRunningSprite = rightMiddleRunningSprite;
            this.leftMiddleRunningSprite = leftMiddleRunningSprite;
            this.rightRunningSprite = rightRunningSprite;
            this.leftRunningSprite = leftRunningSprite;
            this.rightPlayerAttack1 = rightPlayerAttack1;
            this.leftPlayerAttack1 = leftPlayerAttack1;
            this.rightPlayerAttack2 = rightPlayerAttack2;
            this.leftPlayerAttack2 = leftPlayerAttack2;
            this.rightEnemyWalk1 = rightEnemyWalk1;
            this.rightEnemyWalk2 = rightEnemyWalk2;
            this.rightEnemyWalk3 = rightEnemyWalk3;
            this.leftEnemyWalk1 = leftEnemyWalk1;
            this.leftEnemyWalk2 = leftEnemyWalk2;
            this.leftEnemyWalk3 = leftEnemyWalk3;
            this.rangedEnemyTexture = rangedEnemyTexture;

            this.sombreroRangedEnemy = sombreroRangedEnemy;
            this.rightSombreroMelee1 = rightSombreroMelee1;
            this.rightSombreroMelee2 = rightSombreroMelee2;
            this.rightSombreroMelee3 = rightSombreroMelee3;
            this.leftSombreroMelee1 = leftSombreroMelee1;
            this.leftSombreroMelee2 = leftSombreroMelee2;
            this.leftSombreroMelee3 = leftSombreroMelee3;
            this.ushankaRangedEnemy = ushankaRangedEnemy;
            this.rightUshankaMelee1 = rightUshankaMelee1;
            this.rightUshankaMelee2 = rightUshankaMelee2;
            this.rightUshankaMelee3 = rightUshankaMelee3;
            this.leftUshankaMelee1 = leftUshankaMelee1;
            this.leftUshankaMelee2 = leftUshankaMelee2;
            this.leftUshankaMelee3 = leftUshankaMelee3;
            this.fezRangedEnemy = fezRangedEnemy;
            this.rightFezMelee1 = rightFezMelee1;
            this.rightFezMelee2 = rightFezMelee2;
            this.rightFezMelee3 = rightFezMelee3;
            this.leftFezMelee1 = leftFezMelee1;
            this.leftFezMelee2 = leftFezMelee2;
            this.leftFezMelee3 = leftFezMelee3;

            rightJumpSprite = rightStandingSprite;
            leftJumpSprite = leftStandingSprite;

            this.startScreen = startScreen;
            this.buttonFrame = buttonFrame;
            this.roundedFrame = roundedFrame;
            this.upgradeScreen = upgradeScreen;
            this.pauseScreen = pauseScreen;
            this.nextWaveScreen = nextWaveScreen;
            this.gameOver = gameOver;
            this.youWin = youWin;
            this.controlScreen = controlScreen;

            this.basePlatform = basePlatform;
            this.notBasePlatform = notBasePlatform;

            this.metalBack = metalBack;

            //For the bars for health and stamina
            this.healthbar = healthbar;
            this.staminabar = staminabar;

            this.groundPoundTip = groundPoundTip;
            this.damageUpTip = damageUpTip;
            this.staminaUpTip = staminaUpTip;
            this.healthUpTip = healthUpTip;
            this.dashTip = dashTip;
            this.dashUpTip = dashUpTip;

            this.unlockablesUI = unlockablesUI;
        }
    }
}
