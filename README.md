# Grace Connect 🙏

**Connecting people to God and to each other**  
A modern church community app built for Grace Community Church (and beyond).

**Live Web Demo** → [coming soon]  
**Mobile App** → iOS, Android & Windows (built with .NET MAUI Blazor Hybrid)

---

## 🎯 MVP Features

We are currently building the **Minimum Viable Product (MVP)** with the following priorities:

| Priority | Feature                    | Description |
|----------|----------------------------|-----------|
| 1        | Authentication            | Login / Register with Email + Social (Google/Apple). Three roles: Member, Volunteer, Admin |
| 2        | Home Dashboard            | Welcome screen showing upcoming events, announcements, and quick links |
| 3        | Event Calendar + Registration | Calendar view, event details, one-click registration/RSVP |
| 4        | Live Streaming            | YouTube live embed + upcoming service countdown + notifications |
| 5        | Sermon / Media Library    | Searchable library of past sermons, audio, video, and notes |
| 6        | Volunteer Scheduling      | Shift signup, availability, task assignments *(current church pain point)* |
| 7        | Prayer Requests           | Submit private or public prayer requests (with moderation) |
| 8        | Announcements             | Church-wide push notifications and news feed |
| 9        | Church Directory          | Member directory with privacy controls *(optional in MVP)* |

---

## 🛠 Tech Stack

**UI / Frontend**  
- .NET MAUI Blazor Hybrid (mobile + desktop)  
- Blazor Web App (Server/Auto mode) for the web version

**Backend API**  
- .NET 10 Web API

**Database**  
- PostgreSQL (via Supabase)

**Authentication**  
- Supabase Auth (Email + Social login + Role management)

**File Storage**  
- Supabase Storage or Azure Blob Storage

**Real-time**  
- SignalR (built into .NET)

**Hosting**  
- Azure App Service (Web + API)

---

## 🚀 How to Run Locally

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 (with MAUI workload) **or** VS Code + C# Dev Kit
- PostgreSQL (or use Supabase local development)

### Steps
1. Clone the repo
   ```bash
   git clone https://github.com/skwong-code/GraceConnect.git
   cd GraceConnect
