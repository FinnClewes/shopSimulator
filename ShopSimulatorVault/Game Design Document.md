_Survive as many days as you can running a brand-new charity shop._

**Title page:** [Prototype screenshot] · Finn Clewes · BSc (Hons) Applied Computing · [Submission date]

## 2. Table of Contents

[[#3. Game Overview]]
	[[#3.1 Game Concept]]
	[[#3.2 Feature Set]]
	[[#3.3 Genre]]
	[[#3.4 Target Audience]]
	[[#3.5 Game Flow Summary]]
	[[#3.6 Look and Feel]]
	[[#3.7 Project Scope]]
[[#4. Gameplay and Mechanics]]
	[[#4.1 Gameplay]]
		[[#4.1.1 Game Progression]]
	[[#4.2 Mechanics]]
		[[#4.2.1 Physics]]
		[[#4.2.2 Movement]]
		[[#4.2.3 Objects]]
		[[#4.2.4 Actions]]
		[[#4.2.5 Combat / Conflict]]
		[[#4.2.6 Economy]]
	[[#4.3 Screen Flow]]
		[[#4.3.1 Screen Flow Chart]]
		[[#4.3.2 Screen Descriptions]]
	[[#4.4 Game Options]]
	[[#4.5 Replaying and Saving]]
[[#5. Story, Setting and Character]]
	[[#5.1 Story and Narrative]]
		[[#5.1.1 Back Story]]
		[[#5.1.2 Plot Elements]]
		[[#5.1.3 Game Progression]]
		[[#5.1.4 Cut Scenes]]
	[[#5.2 Game World]]
		[[#5.2.1 General Look and Feel]]
		[[#5.2.2 Area 1 Shop Floor]]
		[[#5.2.3 Area 2 Back Room]]
	[[#5.3 Characters]]
		[[#5.3.1 Player (Manager)]]
		[[#5.3.2 Customers (3 temperaments)]]
[[#6. Levels]]
	[[#6.1 Day 1]]
	[[#6.2 Later Days]]
[[#7. Interface]]
	[[#7.1 Visual System]]
	[[#7.2 Control System]]
	[[#7.3 Audio]]
	[[#7.4 Music]]
[[#8. Artificial Intelligence]]
	[[#8.1 Opponent AI]]
	[[#8.2 Enemy AI]]
	[[#8.3 Non-combat Characters]]
	[[#8.4 Friendly Characters]]
	[[#8.5 Support AI]]
		[[#8.5.1 Collision]]
		[[#8.5.2 Pathfinding]]
[[#9. Technical]]
	[[#9.1 Target Hardware]]
	[[#9.2 Development hardware/software]]
		[[#9.2.1 Hardware]]
		[[#9.2.2 Software]]
	[[#9.3 Procedures and standards]]
	[[#9.4 Game Engine]]
	[[#9.5 Network]]
	[[#9.6 Scripting Language]]
[[#10. Game Art]]
	[[#10.1 Concept Art]]
	[[#10.2 Style Guides]]
	[[#10.3 Characters]]
	[[#10.4 Environments]]
	[[#10.5 Equipment]]
	[[#10.6 Cut scenes]]
	[[#10.7 Miscellaneous]]
[[#11. Project Management]]
	[[#11.1 Methodology]]
	[[#11.2 Schedule and Time Management]] 
		[[#11.2.1 Key dates]] 
		[[#11.2.2 Weekly timetable and work sessions]] 
		[[#11.2.3 Other deadlines by term week]] 
		[[#11.2.4 Hours and sprint plan]] 
		[[#11.2.5 Priorities]] 
		[[#11.2.6 Risks and how I handle them]] 
		[[#11.2.7 Hours log]] 
	[[#11.3 Schedule management]] 
	[[#11.4 Version control]] 
	[[#11.5 Risk Analysis]] 
	[[#11.6 Test Plan]] 
	[[#11.7 Scope Reduction Plan]] 
[[#12. Appendices]] 
	[[#12.1 Credits]] 
	[[#12.2 References]] 
	[[#12.3 Project logs]]
# 3. Game Overview

## 3.1 Game Concept

You are the manager of a new location in a chain of charity shops. By day, customers donate items and buy stock. You accept donations, clean them for a higher value, stock them on shelves, mop the floor, and haggle with buyers at the till in a timing minigame. Each day has a time limit. Buying shop expansions grows the business, but also your rent. At the start of the week you draw a challenge card, and each night you spend your earnings on shop upgrades. Fail a card at the end of the week or miss the weekly rent, and the run ends. There is no win state: the goal is to survive more days than other players.

## 3.2 Feature Set

- 3D first-person shop management: walk around the shop to work the till, stock shelves, sort and clean donations, and mop the floor
- Day/night cycle with a time limit per day and rising difficulty
- Donation processing: sort the donation box (keep or bin), clean (scored 1.0–2.0), stock shelves
- Timing-bar sales minigame that changes the sale price
- Challenge cards drawn on night 1 of each week (selling, rent increase, damaged decorations), judged at the end of the week (night 7)
- Nightly shop (decorations, shelves, cleaning supplies, shop expansions)
- Shop expansion tiers, bought with money and gated by week; bigger shop means more customers, more slots and higher rent
- Floor mopping chore
- Weekly rent (7-day week)
- Fixed shop layout: shelves and decorations appear in pre-built slots in the scene when bought (no runtime editor)
- Haggling minigame and cleaning multiplier, with a customer patience multiplier
- Online leaderboard of days survived via Unity Gaming Services

## 3.3 Genre

Single-player 3D first-person shop-management simulation with survival/score-attack elements and skill minigames.

## 3.4 Target Audience

Ages 12+, fans of cosy-but-pressured management games (_Supermarket Simulator_, _Papers, Please_, _Dave the Diver_-style loops). Casual to mid-core PC players who enjoy leaderboard competition. PEGI 3–7.

## 3.5 Game Flow Summary

**Interface:** Main Menu → (Leaderboard / Options) → New Game → Day (time limit) → Night (card on night 1 of each week + shop) → next Day → … → Game Over → Submit score → Leaderboard. **In game:** Day starts → customers arrive to donate or buy → player walks the shop to sort donations, clean items, stock shelves, mop the floor and serve the till → day ends when the timer runs out → night: on night 2 of each week pull a card, and every night buy upgrades (bought shelves and decorations appear in their pre-built slots) → next day. At the end of day 7 of each week, the card is judged and rent is due.

## 3.6 Look and Feel

Warm, cosy, stylised low-poly 3D. A cluttered, charming shop with mismatched furniture and handwritten tags. Tension comes from UI and music escalating as days progress. 
Mood board: [insert 3–5 images].

## 3.7 Project Scope

|Item|Number|
|---|---|
|Locations|1 shop with 2 expansion tiers (3 if time allows): shop floor, back room, extra units|
|Levels|1 endless, escalating day structure|
|NPC types|3 temperaments (patient, normal, impatient) with varied models **[TO DECIDE: model count]**|
|Donation types|4 (plates, books, t-shirts, balls)|
|Decorations|2 (plant, statue)|
|Shelf types|1 (holds 12 items)|
|Other shop items|Cleaning supplies|
|Card types|3 (selling, rent increase, damaged decorations)|
|Minigames|2 (cleaning, selling/haggling)|
|Chores|1 (mopping)|
|Weapons|0|

**Deliverables:** January 2027: this GDD, the Semester 1 report and a playable greybox demo (primitive shapes, no final art or audio). End of March 2027: the finished game, improved using examiner feedback. See 11.2.

---

# 4. Gameplay and Mechanics

## 4.1 Gameplay

### 4.1.1 Game Progression

Progression is visible through **shop expansion**. The shop starts as a small single unit (Tier 1). The player can buy expansions at night once the required week is reached; each adds a new area with more shelf and decoration slots and brings in more customers, but also raises rent (see 4.2.6).

Difficulty rises through:

- More customers per day: customers = tier base + (week − 1) (Tier 1: 5, Tier 2: 8, Tier 3: 11), capped at 14 per day **[tune in playtest]**
- Rent growing every week, plus rent cards and expansion rent increases
- A fixed time limit per day (3 minutes **[tune in playtest]**), so more customers and more chores means more pressure

Upgrades bought at night help the player keep pace.

### 4.1.2 Mission/Challenge Structure

One card is drawn per week, on the night of day 1 of each week (days 1, 8, 15, …). It is picked at random from the two card types below, so it is either a selling challenge or a rent increase. The card is judged at the end of the week (day 7, 14, …), which gives 6 days (days 2 to 7) to complete a selling card. Failing a selling card ends the run.

- **Selling card:** _Sell [number] [clean/dirty/either] [donation type]_. Number: random 2–5. Condition: clean, dirty or either, each with a 1/3 chance. Donation type: random from the 4 types. Example: "Sell 3 clean plates". Sales count from when the card is drawn.
- **Rent card:** That week's rent is increased by a random €10–€45. This is a one-off; the next week's rent returns to the scheduled amount.

### 4.1.3 Puzzle Structure

No puzzles. Decision-making instead: what to clean, what to shelve (storage limits), and what to buy with limited money.

### 4.1.4 Objectives

Survive as many days as possible by completing challenge cards and paying weekly rent. Compete for the top leaderboard position.

### 4.1.5 Play Flow

Day (3-minute limit): the player walks around the shop in first person. Customers arrive and may drop donations in the bin. The player sorts the donation box, cleans items at the cleaning station, stocks shelves, mops mess, and serves customers at the till with the haggling minigame. Customers still waiting when the timer ends leave without buying. Night: on night 1 of the week, draw a card; always visit the night shop to buy upgrades and (when available) expansions. End of week: cards judged and rent paid.

## 4.2 Mechanics

### 4.2.1 Physics

Simple rigid-body physics for carried items; items snap to shelves and the counter **[TO DECIDE]**. The player character uses Unity Physics (entity physics) and interactable objects use standard Unity physics (see 9.4).

### 4.2.2 Movement

- **General:** WASD walk and mouse look in first person, available during the day
- **Other:** Sprint is optional **[cut if short on time]**. Movement is locked while a minigame is open.

### 4.2.3 Objects

- **Picking up / carrying:** The player carries one item at a time. (donation box item → cleaning station → shelf).
- **Storage:** Limited by shelf capacity (12 items per shelf).
- **Fixed furniture slots (no runtime editor):** The shop scene is hand-built in Unity with a fixed number of **shelf slots** and **decoration slots**, each at a set position and each belonging to a shop tier. Slots in unbought tiers are locked. Buying a shelf or decoration at night fills the next free slot of that type, so the player never chooses where it goes. The shop starts with 1 shelf in place.
- **Mess:** Customers can leave mess on the floor (muddy footprints, spills, litter) that appears as patches.

### 4.2.4 Actions

- **Sorting donations:** Customers drop donations into the donation bin. The player goes through the box and decides for each item: donation (keep) or rubbish (discard). [TO DECIDE: what makes an item rubbish, and any penalty for mistakes.]
- **Cleaning:** Take an item to the cleaning station and play the cleaning minigame (uses one cleaning-supply use).
- **Stocking:** Place cleaned or uncleaned items onto shelf slots.
- **Till:** Serve the customer waiting at the till, which opens the haggling minigame.
- **Mopping:** Equip the mop and hold the mouse button over mess patches to remove them.
- **Interacting:** Raycast from the crosshair; context prompts ("Press E").

### 4.2.5 Combat / Conflict

No combat. Two skill minigames and one chore:

- **Cleaning minigame (1.0–2.0):** The item appears in a close-up inspection view covered with 5–8 dirt spots. The player holds the mouse button and scrubs each spot to fade it out within an 8–10 second limit. **Score = 1 + (spots cleaned ÷ total spots)**, so cleaning everything gives 2.0 and doubles the price. The dirt look changes per item type (grime on plates, dust on books, stains on t-shirts, mud on balls). Each clean uses one cleaning-supply use.
- **Selling (haggling) minigame:** A bar with a moving indicator at the till. The player presses **Space** when it is over the green zone. The better the timing, the higher the **selling multiplier**, from **0.5× to 2.5×**.
- **Mopping (chore, not scored):** Mess patches have a dirtiness value that drains while the player mops them. Mess lowers customer patience (e.g. each patch lowers the patience lower bound slightly **[TO DECIDE]**), so ignoring the floor costs money but is quick to fix.

**Final sale price = baseline × cleaning × selling × patience.**

### 4.2.6 Economy

- **Baseline prices:** Plates €5 · Books €1 · T-shirts €7 · Balls €3
- **Sale price = baseline × cleaning (1.0–2.0) × selling (0.5–2.5) × patience (0.5–1.5).** Example: a plate cleaned to 1.7, sold at 2.0× to a customer at 1.2× patience = 5 × 1.7 × 2.0 × 1.2 = €20.40. The theoretical maximum for a plate is 5 × 2 × 2.5 × 1.5 = €37.50.
- **Starting money:** €0. **Starting stock:** a few items already on the shelf **(6 items [tune in playtest]**).
- **Purchases:** Each customer buys exactly one item. If the shelves are empty, the customer leaves without buying, so the supply of donations matters.
- **Cleaning supplies:** Start with 8 uses; buy 5 more uses for €15 at night. Uncleaned items use a cleaning multiplier of 1.0.
- **Rent:** €130 in week 1, rising by €30 each week, plus the expansion rent increases below and a one-off rent card increase (€10–€45) for that week only. Due at the end of day 7, 14, …; failing to pay ends the run.
- **Expected income (ballpark, to be tuned):** average sale ≈ €6–7. Tier 1 week 1 has 35 customers, so an average player earns about €190 against €130 rent (see charity_shop_economy.xlsx), leaving a small margin for supplies and savings.

**Shop expansions (bought at night):**

|Tier|Available from|Cost|Extra rent per week|Customers per day (base)|
|---|---|---|---|---|
|1 (start)|Week 1|n/a|n/a|5|
|2|Week 3|€150|+€60|8|
|3 (if time allows)|Week 6|€300|+€90|11|

Values come from a spreadsheet balance pass (charity_shop_economy.xlsx) and should be re-checked in playtesting. Customers per day are capped at 14, roughly what a player can serve in 3 minutes. [TO DECIDE: raise the cap per tier so later expansions still add income.] Each tier adds shelf slots, decoration slots and floor area to mop. Customers per day also rise by 1 for every week after the first.

**Shop items:**

| Item              | Effect                                                                                                                                                          |
| ----------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Plant             | Raises the patience multiplier's lower bound by 0.05 each (two plants: range 1.5×–0.6×). Caps when the lower bound reaches 1.0× (10 plants). [TO DECIDE: price] |
| Statue            | Patience stays at 1.5× for 4 seconds before it starts to decrease. Statues stack (each adds 4 seconds) [TO DECIDE: price]                                       |
| Shelf (1 type)    | Holds 12 more items [TO DECIDE: price]. The starting layout has 1 shelf filling the first shelf slot.                                                           |
| Cleaning supplies | €15 for 5 uses                                                                                                                                                  |

**Donation types (4):** Plates (€5), books (€1), t-shirts (€7), balls (€3). Items arrive clean or dirty.

**Patience:** Each customer has a patience multiplier that starts at 1.5× and falls toward the lower bound of 0.5× the longer they wait to be served. Impatient customers lose patience fastest. [TO DECIDE: decay rates per temperament, and whether customers leave at the lower bound.]

## 4.3 Screen Flow

### 4.3.1 Screen Flow Chart

[Insert diagram: Main Menu → Game / Leaderboard / Options / Quit. Game → Day → Night Card → Night Shop → Day. Day/Night → Pause. Fail → Game Over → Submit Score → Leaderboard.]

### 4.3.2 Screen Descriptions

- **Main Menu:** New Game, Leaderboard, Options, Quit
- **Options:** Audio, graphics, controls
- **HUD:** Money, day number, time left, rent due, active card, cleaning uses left
- **Donation Box sorting view, Cleaning and Selling minigame overlays**
- **Night Card screen:** Shown on night 1 of each week: the drawn card and its consequences
- **Night Shop screen:** Items, prices, balance, free slots remaining, and the shop expansion available (cost, unlock week, extra rent)
- **Week Summary screen:** Cards judged and rent paid (end of every 7th day)
- **Game Over:** Days survived and reason for failure (card or rent)
- **Leaderboard:** Top scores and the player's rank

## 4.4 Game Options

Volume sliders, mouse sensitivity, key rebinding, and accessibility (colour-blind-safe cue for the green zone).

## 4.5 Replaying and Saving

Runs are roguelite-style: each run starts fresh. Saving mid-run: [TO DECIDE; autosave at end of each day]. The score (total days survived) is submitted to the leaderboard at game over.

---

# 5. Story, Setting and Character

## 5.1 Story and Narrative

### 5.1.1 Back Story

You have been made manager of a brand-new branch of a charity shop chain. Head office expects it to pay its way, with rent due weekly and tasks from head office each night.

### 5.1.2 Plot Elements

Light: head-office challenge cards provide the narrative voice.

### 5.1.3 Game Progression

See 4.1.1. No ending; the run continues until failure.

### 5.1.4 Cut Scenes

None planned **[TO DECIDE: optional intro screen]**.

## 5.2 Game World

### 5.2.1 General Look and Feel

Small high-street charity shop in a cosy town.

### 5.2.2 Area #1: Shop Floor

Shelves and decorations in pre-built slots, till, customer queue area, donation bin. Connects to the back room and the street. Expansion tiers open extra units with more slots.

### 5.2.3 Area #2: Back Room

Cleaning station, night shop terminal.

## 5.3 Characters

### 5.3.1 Player (Manager)

First-person, no visible character. Walks freely around the shop during the day. Statistics are shop stats (money, rent, patience bonus, storage).

### 5.3.2 Customers (3 temperaments)

All customers have a patience multiplier (1.5× falling to 0.5×) that drops while they wait to be served.

- **Patient:** Slowest decrease
- **Normal:** Average decrease
- **Impatient:** Fastest decrease

Not every customer donates. Some put items in a donation bin and then buy something; others only buy. Each customer buys exactly one item.

---

# 6. Levels

One endless level (the shop) with escalating days.

## 6.1 Day #1

- **Synopsis:** Gentle introduction to donating, cleaning, shelving and selling
- **Introductory material:** Short manager briefing
- **Objectives:** Learn the loop. No card on day 1 (the card is drawn on night 1); first rent due at end of day 7. 5 customers.
- **Physical description / Map:** [Insert floor plan]
- **Critical path:** Sort donations → clean → stock shelf → mop → serve till → night shop
- **Encounters:** Few customers, mostly patient
- **Walkthrough:** [Write after prototype]
- **Closing material:** Night card and shop

## 6.2 Later Days

Customers: tier base (5 / 8 / 11) + (week − 1). Rent: €130 in week 1, +€30 each week, plus expansion rent and rent cards. Time limit: 3 minutes per day.

## 6.4 Training Level

Day 1 acts as the tutorial.

---

# 7. Interface

## 7.1 Visual System

- **HUD:** See 4.3.2
- **Menus:** Unity UI
- **Rendering System:** Unity URP
- **Camera:** First-person free movement; close-up views for the cleaning minigame and till
- **Lighting:** Baked, warm interior; day vs. night variation

## 7.2 Control System

|Action|Input|
|---|---|
|Move|WASD|
|Look|Mouse|
|Interact / pick up / drop|E|
|Mop / scrub (hold)|Left Mouse|
|Sprint (optional)|Left Shift|
|Minigame action|Space|
|Pause|Esc|

## 7.3 Audio

Shop ambience, street sounds.

## 7.4 Music

Calm loop by day; tension rising with difficulty.

## 7.5 Sound Effects

Door bell, till, cleaning, item pickup, minigame hit/miss, card flip, rent warning.

## 7.6 Help System

Day 1 prompts and a pause-menu controls and rules page.

---

# 8. Artificial Intelligence

## 8.1 Opponent AI:
None.
## 8.2 Enemy AI: 
None.
## 8.3 Non-combat Characters:
Customers use a state machine: enter → (optionally) drop donation in bin → browse shelves → take an item from a shelf (or leave if none) → join the till queue → wait for the player (patience multiplier decays by temperament, mess and decoration effects) → haggle → leave. They may leave mess behind. All customers still in the shop when the timer ends leave.
## 8.4 Friendly Characters:
None beyond customers.
## 8.5 Support AI:
### 8.5.1 Collision:
Standard Unity colliders for interactables and NavMesh agents. The player character, floor and walls use Unity Physics colliders baked from a subscene (see 9.4).
### 8.5.2 Pathfinding:
Unity NavMesh

---

# 9. Technical

## 9.1 Target Hardware
Windows PC [TO DECIDE: min specs]
## 9.2 Development hardware/software
### 9.2.1 Hardware
**Processor:** 12th Gen Intel(R) Core(TM) i7-1255U
**RAM:** 16GB
**Graphics Card:** Intel(R) Xe Graphics (128MB)
### 9.2.2 Software
Windows 11, Unity 6000.3.10.f1, Visual Studio
## 9.3 Procedures and standards
C# naming conventions, folder structure, regular commits
## 9.4 Game Engine
Unity, chosen because it was learned in college.

**Player controller and scene setup.** The first-person player uses Unity's Character Controller package (Standard Characters, First Person sample), which runs on Unity's entity (DOTS) systems with Unity Physics and Entities Graphics. Objects in a **subscene** are baked into entities. In this project the subscene holds the player and character prefabs, the floor, walls and any other solid object the player must not walk through (standard Box Colliders, baked by Unity Physics). Everything else lives in the normal scene as ordinary GameObjects: the Main Camera (which copies the character's View entity every frame), the GameManager, UI, customers (NavMesh agents) and interactable objects.

**Interaction.** An `Interactor` script on the Main Camera fires a `Physics.Raycast` from the camera against colliders on an Interactable layer. Objects implement an `IInteractable` interface (`Prompt` and `Interact()`), and a "Press E" prompt shows while the player looks at one. Because entity physics and standard physics are separate worlds, an interactable that must also block the player needs a collider in each world.

**[TO DECIDE: if this integration costs too much time, switch to Unity's standard `CharacterController` component so everything lives in one normal scene.]**
## 9.5 Network
Unity Gaming Services **Leaderboards** for days survived. Requires Unity Authentication (anonymous sign-in) and a leaderboard configured in the Unity Cloud dashboard. Handle offline play gracefully.
## 9.6 Scripting Language
C#

---

# 10. Game Art

> For Section 1 the build is a greybox (primitive shapes, placeholder UI). Final art and audio are Section 2 tasks, so the items below describe the eventual plan.
## 10.1 Concept Art: 
[Mood boards, sketches]
## 10.2 Style Guides 
[Palette, shape language, texture style]
## 10.3 Characters 
Customer models for 3 temperaments
## 10.4 Environments
Shop floor, back room, exterior
## 10.5 Equipment
4 donation item types, 2 decorations, 2 shelf type, cleaning station, till
## 10.6 Cut scenes
None
## 10.7 Miscellaneous 
[UI, card art, logo]

---

# 11. Project Management

## 11.2 Schedule and Time Management

**What is being delivered.** The project has two stages. **Stage 1 (January 2027):** this GDD, the Semester 1 report, and a playable **greybox demo** (primitive shapes, placeholder UI) showing one full playable week. **Stage 2 (to the end of March 2027):** the finished game, built using examiner feedback, with cards, shop expansion, leaderboard, menus, art, audio and polish. The Project 1 Semester 1 Report and the presentation/demo in the first week of January are the official Stage 1 deadlines.

**Constraints.** I am taking six other classes (5 credits each) in Semester 1, with assignments and labs throughout the term, and this project is worth 5 credits. In Semester 2 the project is worth double the credits, so I have more time to allocate. I have a mentor meeting every **Friday morning**; each Friday I bring a short demo or progress summary and one question.

### 11.2.1 Key dates

| Date                    | Event                                                                                                                                        |
| ----------------------- | -------------------------------------------------------------------------------------------------------------------------------------------- |
| Wed 21 Oct 2026         | Plan starts (term week 7)                                                                                                                    |
| Wed 28 Oct              | Plan revised (reading week); no build progress yet, so Sprint 1 restarts today                                                               |
| Thu 5 Nov               | First playable selling day (end of Sprint 2)                                                                                                 |
| Fri 13 Nov              | Mentor meeting: demo of a playable selling day with donations, cleaning and patience                                                         |
| Sat 2 Jan 2027, 23:55   | Official: Semester 1 Report due (assessment sheet says "Sunday 2nd January"; 2 Jan 2027 is a Saturday, so confirm against the project brief) |
| Week of 4 Jan 2027      | Official: presentation/demo of the greybox (sheet says "Monday 3rd January"; Monday is 4 Jan, confirm)                                       |
| Mon 18 Jan              | Semester 2 classes start                                                                                                                     |
| Thu 21 Jan              | Feature-complete greybox (Sprint 13)                                                                                                         |
| Fri 12 Mar              | Feature freeze                                                                                                                               |
| Fri 19 Mar              | Target finish                                                                                                                                |
| Mon 22 Mar to Fri 2 Apr | Easter break (no classes)                                                                                                                    |
| **Wed 31 Mar**          | **Personal deadline: game finished (end of March)**                                                                                          |

Semester 2 timetable, examiner feedback and assessment dates are not known yet, so Semester 2 work sessions will be planned on once they are available.
### 11.2.2 Weekly timetable and work sessions

Proposed sessions in a normal term week:

|Session|Time|Hours|
|---|---|---|
|Friday afternoon (after the mentor meeting)|13:00 to 17:00|4|
|Tuesday morning|9:15 to 12:15|3|
|Wednesday afternoon|13:15 to 15:15|2|
|Thursday morning|9:15 to 11:15|2|
|**Fixed total**||**11**|
|Flex / catch-up (optional)|One weekday evening, 18:30 to 21:00, or Saturday daytime|2 to 3|

In heavy assessment weeks I use only some of these sessions. To catch up on this, I spend extra time on weeks with no classes/assignments due. For Semester 2, the sessions will be re-planned when the new timetable is known.

### 11.2.3 Other deadlines by term week

Semester 1, from my assessment schedule.

|Term week|Dates|Deadlines|
|---|---|---|
|7|19 to 25 Oct|AI Engineering Assignment 1 due (25%); Assignment 2 given|
|Reading week|26 to 30 Oct|None|
|8|2 to 8 Nov|Game Dev in C++ CA2 due (20%)|
|9|9 to 15 Nov|**Cloud App Development assignment (45%)**; C++ CA3 given|
|10|16 to 22 Nov|Quizzes only (lightest week)|
|11|23 to 29 Nov|**Mobile Game Dev CA2 (40%); Mobile App Assignment 2 due Sun 29 Nov (60%)**; AI quiz (10%)|
|12|30 Nov to 6 Dec|**AI Assignment 2 (35%)**|
|13|7 to 13 Dec|**Cloud practical exam (45%); Mobile Game Dev CA3 (30%); AI labs (20%) and presentations**|
|14|14 to 18 Dec|**C++ CA3 (60%)**; AI presentations continued (10%)|
|Christmas break|19 Dec to 3 Jan|No classes; report due 2 Jan|

Weeks 11 to 14 are the crunch, so the plan keeps those sprints light (2 to 4 hours).

### 11.2.4 Hours and sprint plan

Planned hours vary by week to fit the deadlines above: about **86 hours in Semester 1** (to 7 Jan) and **150 hours in Semester 2** (8 Jan to 25 Mar), about 236 in total. Semester 2 is planned at about 14 hours a week (12 to 16), which is below what double credits could allow, to leave room for other classes. Extra time goes to the spare buffer (26 to 31 Mar) or to cut items. Each sprint includes 0.5 to 1 hour for a review and log so the appendices do not pile up at the end.

**Semester 1 (January demo).** Sprints run Friday to Thursday, so the Friday mentor meeting is the sprint review and planning.

|Sprint|Dates|Hours|Goal|Main tasks|
|---|---|---|---|---|
|0|Wed 21 Oct to Thu 22 Oct|2|Setup|Unity project (URP) and Git repo, Trello board, send GDD to mentor, UML into Excalidraw|
|1|Wed 28 Oct to Thu 29 Oct|12|Moving in the shop (restart, 28-29 Oct)|First-person controller, interact and carry, day timer, item data, customer spawner, greybox shop scene (cut down because nothing was built before Wed 28 Oct)|
|2|Fri 30 Oct to Thu 5 Nov|15|Customers and selling|Customer state machine, shelf slots and stocking, till queue, haggling minigame, sale calculator, money and HUD, donation bin, cleaning station. Fri 30 Oct and Sat 31 Oct are free (reading week)|
|3|Fri 6 Nov to Thu 12 Nov|8|Donations, cleaning, patience (demo Fri 13 Nov)|Donation sorting, cleaning minigame, patience system, rent system. **Demo at the Fri 13 Nov mentor meeting** (playable selling day)|
|4|Fri 13 Nov to Thu 19 Nov|13|Game over and night shop|Game over, day/night/week flow, night shop UI, supplies, plant and shelf purchases, classmate playtest and fixes|
|5|Fri 20 Nov to Thu 26 Nov|4|Fix and document|Bug fixes, update GDD mechanics and economy sections|
|6|Fri 27 Nov to Thu 3 Dec|3|GDD gaps|Fill remaining TO DECIDE items, draft test plan|
|7|Fri 4 Dec to Thu 10 Dec|2|Hold (exam week)|Bug fixes only|
|8|Fri 11 Dec to Thu 17 Dec|3|GDD admin|Credits, references, risk analysis|
|9|Fri 18 Dec to Thu 24 Dec|10|Finalise report and build|Final bug fixes, balance check, finalise GDD, Semester 1 report|
|10|Fri 25 Dec to Thu 31 Dec|2|Rest week (optional)|Optional: proofread, test build on a clean run|
|11|Fri 1 Jan to Thu 7 Jan|12|Report and January demo|Submit report, demo build and script, rehearse, fix demo-blocking bugs|

**Semester 2 (finished game by the end of March).**

|Sprint|Dates|Hours|Goal|Main tasks|
|---|---|---|---|---|
|12|Fri 8 Jan to Thu 14 Jan|16|Features I: cards and growth|Cards (selling, rent), Tier 2 expansion, rubbish sorting, statue, per-temperament patience, fixes from January demo|
|13|Fri 15 Jan to Thu 21 Jan|14|Features II: feature-complete|Leaderboard (Unity Gaming Services), mess and mopping, main menu, options, pause, tutorial prompts. **Feature-complete greybox.** Semester 2 classes start Mon 18 Jan|
|14|Fri 22 Jan to Thu 28 Jan|14|Feedback triage and playtest 1|Triage examiner feedback, playtest round 1, fixes, balance|
|15|Fri 29 Jan to Thu 4 Feb|14|Feedback must-fix, Tier 3|Examiner must-fix list, Tier 3 and per-tier customer cap|
|16|Fri 5 Feb to Thu 11 Feb|14|Art pass 1: environment|Asset packs and licences, replace shop environment, lighting|
|17|Fri 12 Feb to Thu 18 Feb|14|Art pass 2: items, customers, UI|Item models/icons, customer models and animations, UI skin|
|18|Fri 19 Feb to Thu 25 Feb|14|Audio and polish|Sound effects, music, juice (minigame feedback, popups, particles)|
|19|Fri 26 Feb to Thu 4 Mar|14|Playtest 2 and balance|Playtest round 2, balance, performance, bug fixing|
|20|Fri 5 Mar to Thu 11 Mar|12|Feedback should-fix and bugs|Examiner should-fix list, bug fixing, GDD v2. **Feature freeze Fri 12 Mar**|
|21|Fri 12 Mar to Thu 18 Mar|12|Finish (target finish Fri 19 Mar)|Final polish, regression test, documentation, proofread GDD v2. **Target finish Fri 19 Mar**|
|22|Fri 19 Mar to Thu 25 Mar|12|Final checks (Easter break)|Final build, clean-machine test, last blockers, regression test, submission pack. Easter break (22 Mar to 2 Apr): no classes|

Buffer: Fri 26 Mar to Wed 31 Mar, 0 to 6 hours, for anything that slipped. Good Friday (26 Mar) and Easter Sunday (28 Mar) are not work days.

### 11.2.5 Priorities

- **For the January demo (must have):** first-person loop, customers and till queue, shelves and stocking, haggling minigame, cleaning minigame, donation sorting, rent and game over, night shop (supplies, plant, shelf).
- **For the finished game (must have):** one weekly card (selling and rent), Tier 2 expansion, leaderboard, main menu and options, examiner must-fix list, art pass, sound effects, two playtest rounds.
- **Should / could have:** statue, per-temperament patience, rubbish sorting, mess and mopping, Tier 3 with a per-tier customer cap, music, camera polish.

### 11.2.6 Risks and how I handle them

- **Sprint 1 had no progress by Wed 28 Oct.** It was cut to 12 hours (the first-person controller, carrying, day timer, spawner and greybox scene) and the customer behaviour, selling minigame and money moved into Sprint 2 (15 hours, using the free Fri 30 Oct and Sat 31 Oct). Donation sorting, cleaning and patience moved to Sprint 3. If Sprint 2 slips, the Fri 13 Nov demo shows what exists.
- **The entity (DOTS) character controller is harder to integrate** than a normal GameObject controller (separate physics, subscene baking). If it keeps costing time, switch to the standard `CharacterController` component (see 9.4).
- **Weeks 11 to 14 are heavy.** Sprints 5 to 8 are 2 to 4 hours each, so only bug fixes and GDD work happen then. The January demo only needs sprints 0 to 4.
- **Semester 2 dates are unknown.** The plan is re-checked when the new timetable and the examiner feedback date arrive.
- **Examiner feedback may be larger than planned.** Sprints 14, 15 and 20 are reserved for it; art and polish are cut before feedback fixes.
- If a sprint ends with fewer than 70% of its planned hours, I drop the lowest-priority task from the next sprint (section 11.7). Cut items go on the Stage 2 backlog.
- Never cut: the must-have lists above, testing, and the GDD.

### 11.2.7 Hours log

| Sprint | Date     | Hours | What I did                                                                                                              |
| ------ | -------- | ----- | ----------------------------------------------------------------------------------------------------------------------- |
| 0      | 21/10/26 | 2     | plan sprint for the rest of the semester, rewrote GDD, updated uml                                                      |
| 1      | 29/10/26 | 6     | re-allocated time and tasks for each sprint, updated GDD, made character controller, made basic interact raycast system |
|        |          |       |                                                                                                                         |

## 11.3 Schedule management

Trello, it is an easy to use tool that I am familiar with.

## 11.4 Version control

GitHub

## 11.5 Risk Analysis

Balancing difficulty with economy and timing. Scope creep. Minigame bugs. UGS setup problems as I am unfamiliar with the system.

## 11.6 Test Plan

Functional tests for economy, cards and rent; playtest with testers; feedback form; balance iterations.

## 11.7 Scope Reduction Plan

If time runs short, features are dropped in the order below, starting at number 1. Each one can go without breaking the core loop (walk the shop, serve customers, haggle, clean, stock, pay rent, survive days). Time estimates are rough.

**Already dropped**

| Feature                  | Reason                                                                                                             | Hours saved |
| ------------------------ | ------------------------------------------------------------------------------------------------------------------ | ----------- |
| Damaged decorations card | Lowest value of the three card types; needs a damage state, replacement cost and extra UI, no 'fail' state decided | about 3     |

**Drop order**

|Order|Feature|What replaces it|Hours saved|
|---|---|---|---|
|1|Tier 3 expansion|The shop has two tiers only|about 3|
|2|Sprint|Walk speed is fixed|about 1|
|3|Statue decoration|Plants are the only decoration; patience bonus still works|about 2|
|4|Mess and mopping|No floor chore; customers do not leave mess|about 5|
|5|Separate patience rates per temperament|All customers use one patience rate; the three types stay as names only|about 1|
|6|Rubbish option in donation sorting|All donated items are accepted|about 2|
|7|Online leaderboard (Unity Gaming Services)|A local high score for most days survived|about 3|
|8|Tier 2 expansion|Shop starts with more slots, no expansion purchase|about 5|

**Art and audio fallbacks (Semester 2):** customer walk animations fall back to sliding models; music falls back to sound effects only.

**Never dropped:** first-person movement, customers and till queue, haggling minigame, cleaning minigame, shelves and stocking, night shop (supplies, plants, shelves), rent and game over, selling and rent cards, the GDD and testing.

**When I decide**

- **Every Friday:** hours worked are checked against the sprint plan. If a sprint ended under 70% of its planned hours, the next item on the list is dropped.
- **Fri 13 Nov (after the demo):** if the core loop is not playable, drop items 1 to 3 and the optional Semester 2 items (Tier 3, music, camera polish).
- **Fri 11 Dec:** the January demo scope is frozen. Nothing from the Semester 2 list is started before the report is submitted.
- **Fri 22 Jan (after Sprint 13):** if the greybox is not feature-complete, drop items 4 to 6.
- **Fri 12 Feb (after Sprint 16):** if the art pass is behind, keep greybox models for items and customers and spend the time on feedback fixes.
- **Fri 12 Mar (feature freeze):** nothing new is added, and unfinished items are dropped.

---

# 12. Appendices

## 12.1 Credits

Images · Models · Animations · Audio · Cameras · Player controllers · Other

- **Player controllers:** Unity Character Controller package, Standard Characters sample (First Person), Unity Technologies.

## 12.2 References

[First Person Character Controller Setup](https://docs.unity3d.com/Packages/com.unity.charactercontroller@1.0/manual/get-started-first-person.html) [Unity Physics 6.5: collider components](https://docs.unity3d.com/Packages/com.unity.physics@6.5/manual/physics-collider-components.html) [Unity Physics changelog](https://docs.unity3d.com/Packages/com.unity.physics@6.6/changelog/CHANGELOG.html)

## 12.3 Project logs

[Sprint docs, Trello screenshots]