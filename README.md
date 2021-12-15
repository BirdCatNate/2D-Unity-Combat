# 2D-Unity-Combat
A repository full of building blocks for any 2D combat system in unity.

This is a repository which I will be adding to over time. I'm not making any promises for a "complete" combat system quite yet.
Nonetheless - as I do more and more game jams I'll add reusable code to it so I won't have to reinvent the wheel every time.

Feel free to use these scripts for your own projects! And if there are any issues / recommendations, please let me know!

## Current contents:

### Scripts/
- **CharacterComponents/** - Components to attach to players and enemies
    - **Health.cs** - handles protected changes to health. Most scripts in this repository are dependent on this script.
    - **HealthBar.cs** - optional and modular script which can be used to make a runescape-esque healthbar. Check a future example to see proper usage.

- **ProjectileComponents/** - Components to create complex projectile systems. (Used in Goblin Gambler)
    - **AccelerateToTarget.cs** - used to make "heat-seeking" projectiles. And returning boomerangs!
    - **ProjectileCollision.cs** - handles damage, bouncing, piercing, and destruction for moving projectiles. Requires a Collider2D component.
    - **DestroyAfterDuration.cs** - given a duration, destroy the gameObject this is attached to.
    - **OnDestroySummonPrefab.cs** - useful for bombs, for example. A bomb object on destruction can spawn an "explosion" object
    - **OnStartAddForce.cs** - useful for linearly projectiles. Requires a Rigidbody2D component.
    - **OnStartDamagePop.cs** - useful for melee attacks and explosions.
    - **SpriteAnimationLoop.cs** - manages sprite animations for projectiles.