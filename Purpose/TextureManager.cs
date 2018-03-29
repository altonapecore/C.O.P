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
        private Texture2D rightCrouchSprite;
        private Texture2D leftCrouchSprite;
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


        //sprite properties
        public Texture2D RightCrouchSprite { get { return rightCrouchSprite; } }
        public Texture2D LeftCrouchSprite { get { return leftCrouchSprite; } }
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
        public Texture2D RangedEnemyTexture { get { return rangedEnemyTexture; } }

        //constructor
        public TextureManager(Texture2D leftCrouchSprite, Texture2D rightCrouchSprite, Texture2D leftStandingSprite,
            Texture2D rightStandingSprite, Texture2D leftMiddleRunningSprite, Texture2D rightMiddleRunningSprite,
            Texture2D leftRunningSprite, Texture2D rightRunningSprite, Texture2D rightPlayerAttack1, Texture2D leftPlayerAttack1, Texture2D rightPlayerAttack2, Texture2D leftPlayerAttack2,
            Texture2D rightEnemyWalk1, Texture2D rightEnemyWalk2, Texture2D rightEnemyWalk3, Texture2D leftEnemyWalk1, Texture2D leftEnemyWalk2, Texture2D leftEnemyWalk3, Texture2D rangedEnemyTexture)
        {
            this.rightCrouchSprite = rightCrouchSprite;
            this.leftCrouchSprite = leftCrouchSprite;
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

            rightJumpSprite = rightStandingSprite;
            leftJumpSprite = leftStandingSprite;

        }
    }
}
