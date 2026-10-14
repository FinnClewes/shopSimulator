# Charity Shop Simulator

_Survive as many days as you can running a brand-new charity shop._

**Title page:** [Prototype screenshot] · [Name] · [Course] · [Submission date]

## 2. Table of Contents

---

# 3. Game Overview

## 3.1 Game Concept

You are the manager of a new location in a chain of charity shops. By day, customers donate items and buy stock. You accept donations, clean them for a higher value, shelve them, and haggle with buyers in a timing minigame. Twice a week you draw a challenge card, and each night you spend your earnings on shop upgrades. Fail a card at the end of the week or miss the weekly rent and the run ends. There is no win state: the goal is to survive more days than other players.

## 3.2 Feature Set

- 3D first-person shop management: free movement while decorating, fixed camera during the day
- Day/night cycle with rising difficulty; a day ends when all customers are served
- Donation processing: sort the donation box (keep or rubbish), clean (scored 1.0–2.0), shelve
- Timing-bar sales minigame that changes the sale price
- Challenge cards drawn on nights 2 and 4 of each week (selling, rent increase, damaged decorations), judged at the end of the week
- Nightly shop (decorations, shelves, cleaning supplies)
- Weekly rent (7-day week)
- Grid-based shop layout: place decorations and shelves each morning before opening
- Haggling minigame and cleaning multiplier, with a customer patience multiplier
- Online leaderboard of days survived via Unity Gaming Services

## 3.3 Genre

Single-player 3D first-person shop-management simulation with survival/score-attack elements and skill minigames.

## 3.4 Target Audience

Ages 12+, fans of cosy-but-pressured management games (_Supermarket Simulator_, _Papers, Please_, _Dave the Diver_-style loops). Casual to mid-core PC players who enjoy leaderboard competition. PEGI 3–7.

## 3.5 Game Flow Summary

**Interface:** Main Menu → (Leaderboard / Options) → New Game → Morning (grid placement) → Day (ends when all customers are served) → Night (card on nights 2 and 4 + shop) → next Day → … → Game Over → Submit score → Leaderboard. **In game:** Morning: walk the shop and place decorations and shelves on the grid → shop opens → customers arrive to donate or buy → player sorts, cleans and sells from a fixed camera → day ends when all customers are served → night: pull a card (nights 2 and 4 of the week), buy upgrades → next day. At the end of day 7 of each week, cards are judged and rent is due.

## 3.6 Look and Feel

Warm, cosy, stylised low-poly 3D. A cluttered, charming shop with mismatched furniture and handwritten tags. Tension comes from UI and increased customers as days progress. Mood board: [insert 3–5 images].

## 3.7 Project Scope

| Item             | Number                                                                                      |
| ---------------- | ------------------------------------------------------------------------------------------- |
| Locations        | 1 (shop floor, back room)                                                                   |
| Levels           | 1 endless, escalating day structure                                                         |
| NPC types        | 3 temperaments (patient, normal, impatient) with varied models **[TO DECIDE: model count]** |
| Donation types   | 4 (plates, books, t-shirts, balls)                                                          |
| Decorations      | 2 (plant, statue)                                                                           |
| Shelf types      | 1 (holds 12 items)                                                                          |
| Other shop items | Cleaning supplies                                                                           |
| Card types       | 3 (selling, rent increase, damaged decorations)                                             |
| Minigames        | 2 (cleaning, selling/haggling)                                                              |

---

# 4. Gameplay and Mechanics

## 4.1 Gameplay

### 4.1.1 Game Progression

Each day is harder than the last. Difficulty ramps through more customers per day and rising rent (+€50 per week, plus rent cards). Days have no time limit and end when every customer has been served, so a bigger crowd means a longer queue and more patience pressure. Customers per day start at 4 and increase by 2 every three days (days 1–3: 4, days 4–6: 6, days 7–9: 8, …), i.e. customers = 4 + 2 × floor((day − 1) / 3). Upgrades bought at night help the player keep pace.

### 4.1.2 Mission/Challenge Structure

Cards are drawn on the nights of days 2 and 4 of each week (days 2, 4, 9, 11, 16, 18, …) . All cards are judged at the end of the week (day 7, 14, …). Failing a selling card ends the run.

- **Selling card:** _Sell _[number]_ [condition]_ [donation type]_. 
	- Number: random 2–5. 
	- Condition: clean, dirty or either, each with a 1/3 chance. 
	- Donation type: random from the 4 types. Example: "Sell 3 clean plates". Sales count from when the card is drawn.
- **Rent card:** That week's rent is increased by a random €10–€45. This is a one-off; the next week's rent returns to the scheduled amount (€920 + €50 per week).
- **Damaged decorations card:** A decoration is damaged, so patience buff is removed, and the player must spend money the following day if they wish to replace them. There is no fail condition on this card. 

### 4.1.3 Objectives

Survive as many days as possible by completing challenge cards and paying weekly rent. Compete for the top leaderboard position.

### 4.1.4 Play Flow

Morning: walk the shop and place shelves and decorations on the grid (the only time the player moves). Day: fixed camera; customers arrive, and the player sorts the donation box, cleans, shelves, and haggles with buyers until all customers are served. Night: on nights 2 and 4 of the week, draw a card; always visit the shop to buy upgrades. End of week: cards judged and rent paid.

## 4.2 Mechanics

### 4.2.1 Physics

Simple rigid-body physics for carried items; items snap to shelves and the counter. Unity default physics.

### 4.2.2 Movement

Fixed position, no player or camera movement. During the day, first person perspective. During the morning decorating phase, top down view.

### 4.2.3 Objects

- **Picking up / moving:** With a fixed camera there is no free carrying. The player clicks items to move them between the donation box, cleaning station and shelves.
- **Storage:** Limited by shelf capacity (12 items per shelf).
- **Grid placement:** The shop floor is divided into a grid. Before opening each morning, the player places and moves decorations and shelves on grid cells. Placement is locked once the shop opens.

### 4.2.4 Actions

- **Sorting donations:** Customers drop donations into the donation bin. The player goes through the box and decides for each item: donation (keep) or rubbish (discard). [TO DECIDE: when this happens, what makes an item rubbish, and any penalty for mistakes.]
- **Buttons:** Open shop / start day, till
- **Talking:** Context prompts ("Sell?")
- **Reading:** Item tags, card text, price breakdown

### 4.2.5 Combat / Conflict

No combat. Two skill minigames:

- **Cleaning minigame:** Produces a score from 1.0 to 2.0 that multiplies the item's baseline price (a 1.7 score gives 1.7×; the best score doubles the price). Each clean uses one use of cleaning supplies. Mechanic: [TO DECIDE, e.g. scrubbing timing or clearing dirt spots].
- **Selling (haggling) minigame:** A bar with a moving indicator. The player presses **Space** when it is over the green zone. The better the timing, the higher the **selling multiplier**, from **0.5× to 2.5×**.

**Final sale price = baseline × cleaning × selling × patience.**

### 4.2.6 Economy

- **Baseline prices:** Plates €5 · Books €1 · T-shirts €7 · Balls €3
- **Sale price = baseline × cleaning (1.0–2.0) × selling (0.5–2.5) × patience (0.5–1.5).** Example: a plate cleaned to 1.7, sold at 2.0× to a customer at 1.2× patience = 5 × 1.7 × 2.0 × 1.2 = €20.40. The theoretical maximum for a plate is 5 × 2 × 2.5 × 1.5 = €37.50.
- **Starting money:** €0
- **Purchases:** Each customer buys exactly one item.
- **Cleaning supplies:** Start with 8 uses; buy 5 more uses for €15 at night. Uncleaned items use a cleaning multiplier of 1.0.
- **Rent:** €920 in week 1, rising by €50 each week (week 2: €970, week 3: €1,020, …), plus a one-off rent card increase (€10–€45) for that week only. Due at the end of day 7, 14, …; failing to pay ends the run.
- Money is spent at night on decorations, shelves and cleaning supplies.

**Shop items:**

|Item|Effect|
|---|---|
|Plant|Raises the patience multiplier's lower bound by 0.05 each (two plants: range 1.5×–0.6×). Caps when the lower bound reaches 1.0× (10 plants). [TO DECIDE: price]|
|Statue|Patience stays at 1.5× for 4 seconds before it starts to decrease. Statues stack (each adds 4 seconds **[ASSUMED]**) [TO DECIDE: price]|
|Shelf (1 type)|Holds 12 more items [TO DECIDE: price]. The starting layout has 1 shelf.|
|Cleaning supplies|€15 for 5 uses|

**Donation types (4):** Plates (€5), books (€1), t-shirts (€7), balls (€3). Items arrive clean or dirty.

**Patience:** Each customer has a patience multiplier that starts at 1.5× and falls toward the lower bound of 0.5× the longer they wait to be served. Impatient customers lose patience fastest. [TO DECIDE: decay rates per temperament, and whether customers leave at the lower bound.]

## 4.3 Screen Flow

### 4.3.1 Screen Flow Chart

[Insert diagram: Main Menu → Game / Leaderboard / Options / Quit. Game → Day → Night Card → Night Shop → Day. Day/Night → Pause. Fail → Game Over → Submit Score → Leaderboard.]

### 4.3.2 Screen Descriptions

- **Main Menu:** New Game, Leaderboard, Options, Quit
- **Options:** Audio, graphics, controls
- **Morning Placement screen:** Grid view for placing shelves and decorations; start-day button
- **HUD:** Money, day number, customers remaining, rent due, active card, cleaning uses left
- **Donation Box sorting view, Cleaning and Selling minigame overlays**
- **Night Card screen:** Shown on nights 2 and 4 of each week: the drawn card and its consequences
- **Night Shop screen:** Items, prices, balance
- **Week Summary screen:** Cards judged and rent paid (end of every 7th day)
- **Game Over:** Days survived and reason for failure (card or rent)
- **Leaderboard:** Top scores and the player's rank

## 4.4 Game Options

Volume sliders, mouse sensitivity, key rebinding, and accessibility (colour-blind-safe cue for the green zone).

## 4.5 Replaying and Saving

Runs are roguelite-style: each run starts fresh. Saving mid-run: autosave at end of each day. The score (total days survived) is submitted to the leaderboard at game over.

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

Shelves, decorations, till, customer queue area, donation counter, cleaning station, night shop terminal. Connects to the street.

## 5.3 Characters

### 5.3.1 Player (Manager)

First-person, no visible character. Moves freely only during morning decorating and is fixed at the counter during the day. Statistics are shop stats (money, rent, patience bonus, storage).

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
- **Objectives:** Learn the loop. No card on day 1 (the first card is drawn on night 2); first rent due at end of day 7. 4 customers.
- **Physical description / Map:** [Insert floor plan]
- **Critical path:** Sort donations → clean → shelve → sell → night shop
- **Encounters:** Few customers, mostly patient
- **Walkthrough:** [Write after prototype]
- **Closing material:** Night card and shop

## 6.2 Later Days

Customers: 4 + 2 × floor((day − 1) / 3), i.e. 4 for days 1–3, 6 for days 4–6, 8 for days 7–9, and so on. Rent: €920 in week 1, +€50 each week, plus rent cards. No time limit per day.

## 6.4 Training Level

Day 1 acts as the tutorial.

---

# 7. Interface

## 7.1 Visual System

- **HUD:** See 4.3.2
- **Menus:** Unity UI
- **Rendering System:** Unity URP
- **Camera:** Top-down fixed in the morning decorating phase; fixed counter view for the rest of the day
- **Lighting:** Baked, warm interior; day vs. night variation

## 7.2 Control System

| Action                            | Input       |
| --------------------------------- | ----------- |
| Place / move grid items (morning) | Left Click  |
| Sort, clean, shelve (day)         | Mouse click |
| Minigame action                   | Space       |
| Pause                             | Esc         |

## 7.3 Audio

Shop ambience, street sounds.

## 7.4 Music

Calm loop by day; tension rising with difficulty. ** [to be decided] **

## 7.5 Sound Effects

Door bell, till, cleaning, item pickup, minigame hit/miss, card flip, rent warning.

## 7.6 Help System

Day 1 prompts and a pause-menu controls and rules page.

---

# 8. Artificial Intelligence

- **8.1 Non-combat Characters:** Customers use a state machine: enter → (optionally) drop donation in bin → browse shelves → choose item → wait for player (patience multiplier decays by temperament and decoration effects) → haggle → leave. The day ends when all customers have been served.
- **8.2 Support AI:**
    - **8.5.1 Collision:** Unity colliders
    - **8.5.2 Pathfinding:** Unity NavMesh

---

# 9. Technical

- **9.1 Target Hardware:** Windows PC [TO DECIDE: min specs]
- **9.2 Development hardware/software:** [Your PC], Unity 6000.3.10f1, Visual Studio
- **9.3 Procedures and standards:** C# naming conventions, folder structure, regular commits
- **9.4 Game Engine:** Unity, chosen because it was learned in college
- **9.5 Network:** Unity Gaming Services **Leaderboards** for days survived. Requires Unity Authentication (anonymous sign-in) and a leaderboard configured in the Unity Cloud dashboard.
- **9.6 Scripting Language:** C#

---

# 10. Game Art

- **10.1 Concept Art:** [Mood boards, sketches]
- **10.2 Style Guides:** Palette, shape language, texture style
- **10.3 Characters:** Customer models for 3 temperaments
- **10.4 Environments:** Shop floor, exterior
- **10.5 Equipment:** 4 donation item types, 2 decorations, 2 shelves, cleaning station, till
- **10.6 Cut scenes:** None
- **10.7 Miscellaneous:** UI, card art, logo

---

# 11. Project Management

- **11.1 Methodology:** [e.g. Scrum, 1–2 week sprints; justify for solo project]
- **11.2 Schedule:** [Milestones: core loop → minigames → cards/night shop → difficulty scaling → leaderboard → polish → submission; with dates]
- **11.3 Schedule management:** Trello
- **11.4 Version control:** GitHub
- **11.5 Risk Analysis:** [Table. Suggested risks: scope creep, balancing difficulty, UGS setup problems, asset shortage, bugs in minigames.]
- **11.6 Test Plan:** [Functional tests for economy, cards and rent; playtest with N testers; feedback form; balance iterations.]

---

# 12. Appendices

- **12.1 Credits:** Images · Models · Animations · Audio · Cameras · Player controllers · Other
- **12.2 References:** [Harvard format]
- **12.3 Project logs:** [Sprint docs, Trello screenshots, vlog links]