namespace ZamAiMart.Client.Models;

/// <summary>
/// Embedded fallback data — used when the API is unreachable (e.g. GitHub Pages demo).
/// </summary>
public static class StaticData
{
    private static readonly List<AIWebsiteDto> _all = new()
    {
        new() { Id=1,  Name="ChatGPT",           Category="AI Chatbots",        PriceINR=1660, IsFree=false, WebsiteURL="https://chatgpt.com",                   PlayStoreUrl="https://play.google.com/store/apps/details?id=com.openai.chatgpt", AppStoreUrl="https://apps.apple.com/app/id6448311069", Description="OpenAI's conversational AI assistant for writing, coding, and analysis.",    LogoURL="https://upload.wikimedia.org/wikipedia/commons/0/04/ChatGPT_logo.svg" },
        new() { Id=2,  Name="Google Gemini",      Category="AI Chatbots",        PriceINR=0,    IsFree=true,  WebsiteURL="https://gemini.google.com",             PlayStoreUrl="https://play.google.com/store/apps/details?id=com.google.android.apps.bard", AppStoreUrl="https://apps.apple.com/us/app/google-gemini/id6477489729", Description="Google's multimodal AI assistant integrated across Google services.",       LogoURL="" },
        new() { Id=3,  Name="Claude",             Category="AI Chatbots",        PriceINR=1660, IsFree=false, WebsiteURL="https://claude.ai",                    Description="Anthropic's AI assistant focused on safety and helpful conversations.",     LogoURL="" },
        new() { Id=4,  Name="Microsoft Copilot",  Category="AI Chatbots",        PriceINR=0,    IsFree=true,  WebsiteURL="https://copilot.microsoft.com",         Description="Microsoft's AI companion powered by GPT-4, integrated with Office 365.",  LogoURL="" },
        new() { Id=5,  Name="Perplexity AI",      Category="AI Chatbots",        PriceINR=1660, IsFree=false, WebsiteURL="https://perplexity.ai",                Description="AI-powered search engine that provides answers with citations.",          LogoURL="" },
        new() { Id=6,  Name="Meta AI",            Category="AI Chatbots",        PriceINR=0,    IsFree=true,  WebsiteURL="https://meta.ai",                      Description="Meta's AI assistant available on WhatsApp, Instagram, and Facebook.",      LogoURL="" },
        new() { Id=7,  Name="Midjourney",         Category="AI Image Generators",PriceINR=830,  IsFree=false, WebsiteURL="https://midjourney.com",               Description="Industry-leading AI art generator known for stunning artistic images.",    LogoURL="" },
        new() { Id=8,  Name="DALL-E 3",           Category="AI Image Generators",PriceINR=1660, IsFree=false, WebsiteURL="https://openai.com/dall-e-3",           Description="OpenAI's advanced image generation model with precise prompt adherence.", LogoURL="" },
        new() { Id=9,  Name="Stable Diffusion",   Category="AI Image Generators",PriceINR=0,    IsFree=true,  WebsiteURL="https://stability.ai",                 Description="Open-source image generation model with extensive customization options.", LogoURL="" },
        new() { Id=10, Name="Adobe Firefly",      Category="AI Image Generators",PriceINR=1700, IsFree=false, WebsiteURL="https://firefly.adobe.com",             Description="Adobe's generative AI designed for safe commercial use.",                LogoURL="" },
        new() { Id=11, Name="Leonardo.AI",        Category="AI Image Generators",PriceINR=1200, IsFree=false, WebsiteURL="https://leonardo.ai",                  Description="AI image generation platform popular among game developers.",             LogoURL="" },
        new() { Id=12, Name="Ideogram",           Category="AI Image Generators",PriceINR=0,    IsFree=true,  WebsiteURL="https://ideogram.ai",                  Description="AI image generator with excellent text rendering capabilities.",           LogoURL="" },
        new() { Id=13, Name="Runway ML",          Category="AI Video Tools",     PriceINR=1200, IsFree=false, WebsiteURL="https://runwayml.com",                 Description="AI-powered video editing and generation platform for creatives.",         LogoURL="" },
        new() { Id=14, Name="Synthesia",          Category="AI Video Tools",     PriceINR=2490, IsFree=false, WebsiteURL="https://synthesia.io",                 Description="Create professional AI videos with avatars in minutes without cameras.",   LogoURL="" },
        new() { Id=15, Name="HeyGen",             Category="AI Video Tools",     PriceINR=2490, IsFree=false, WebsiteURL="https://heygen.com",                   Description="AI video generation platform for creating personalized videos at scale.",  LogoURL="" },
        new() { Id=16, Name="Invideo AI",         Category="AI Video Tools",     PriceINR=2000, IsFree=false, WebsiteURL="https://invideo.io",                   Description="Text-to-video AI tool for marketing and social media content.",           LogoURL="" },
        new() { Id=17, Name="Pictory",            Category="AI Video Tools",     PriceINR=1500, IsFree=false, WebsiteURL="https://pictory.ai",                   Description="Transform blog posts and scripts into engaging short videos.",             LogoURL="" },
        new() { Id=18, Name="GitHub Copilot",     Category="AI Code Assistants", PriceINR=830,  IsFree=false, WebsiteURL="https://github.com/features/copilot",  Description="AI pair programmer that suggests code completions in your IDE.",          LogoURL="" },
        new() { Id=19, Name="Cursor",             Category="AI Code Assistants", PriceINR=1660, IsFree=false, WebsiteURL="https://cursor.sh",                    Description="AI-first code editor with GPT-4 integration for faster development.",     LogoURL="" },
        new() { Id=20, Name="Tabnine",            Category="AI Code Assistants", PriceINR=830,  IsFree=false, WebsiteURL="https://tabnine.com",                  Description="AI code completion tool supporting 30+ programming languages.",            LogoURL="" },
        new() { Id=21, Name="Codeium",            Category="AI Code Assistants", PriceINR=0,    IsFree=true,  WebsiteURL="https://codeium.com",                  Description="Free AI coding assistant with autocomplete and chat features.",           LogoURL="" },
        new() { Id=22, Name="Replit AI",          Category="AI Code Assistants", PriceINR=830,  IsFree=false, WebsiteURL="https://replit.com",                   Description="Cloud-based IDE with AI assistance for coding and deployment.",           LogoURL="" },
        new() { Id=23, Name="Jasper AI",          Category="AI Writing Tools",   PriceINR=3300, IsFree=false, WebsiteURL="https://jasper.ai",                    Description="AI content platform for marketing teams to create brand content.",        LogoURL="" },
        new() { Id=24, Name="Copy.ai",            Category="AI Writing Tools",   PriceINR=3300, IsFree=false, WebsiteURL="https://copy.ai",                      Description="AI marketing copy tool for emails, ads, social media, and blogs.",        LogoURL="" },
        new() { Id=25, Name="Writesonic",         Category="AI Writing Tools",   PriceINR=1250, IsFree=false, WebsiteURL="https://writesonic.com",               Description="AI writer for SEO-optimized content creation.",                          LogoURL="" },
        new() { Id=26, Name="Grammarly",          Category="AI Writing Tools",   PriceINR=0,    IsFree=true,  WebsiteURL="https://grammarly.com",                Description="AI writing assistant for grammar, clarity, and tone improvements.",      LogoURL="" },
        new() { Id=27, Name="Notion AI",          Category="AI Writing Tools",   PriceINR=830,  IsFree=false, WebsiteURL="https://notion.so/product/ai",         Description="AI writing assistant integrated into Notion workspace.",                  LogoURL="" },
        new() { Id=28, Name="ElevenLabs",         Category="AI Voice & Audio",   PriceINR=1660, IsFree=false, WebsiteURL="https://elevenlabs.io",                Description="Hyper-realistic AI voice synthesis and text-to-speech platform.",         LogoURL="" },
        new() { Id=29, Name="Murf AI",            Category="AI Voice & Audio",   PriceINR=1660, IsFree=false, WebsiteURL="https://murf.ai",                      Description="Professional AI voice-over generator for videos and presentations.",      LogoURL="" },
        new() { Id=30, Name="Descript",           Category="AI Voice & Audio",   PriceINR=1250, IsFree=false, WebsiteURL="https://descript.com",                 Description="All-in-one audio/video editor with AI transcription and voice cloning.",  LogoURL="" },
        new() { Id=31, Name="Whisper",            Category="AI Voice & Audio",   PriceINR=0,    IsFree=true,  WebsiteURL="https://openai.com/research/whisper",  Description="OpenAI's open-source automatic speech recognition system.",               LogoURL="" },
        new() { Id=32, Name="Suno",               Category="AI Music Generators",PriceINR=830,  IsFree=false, WebsiteURL="https://suno.com",                     Description="Create complete songs with vocals from a simple text prompt.",            LogoURL="" },
        new() { Id=33, Name="Udio",               Category="AI Music Generators",PriceINR=0,    IsFree=true,  WebsiteURL="https://udio.com",                     Description="AI music generation tool for creating unique tracks in any genre.",       LogoURL="" },
        new() { Id=34, Name="Soundraw",           Category="AI Music Generators",PriceINR=1660, IsFree=false, WebsiteURL="https://soundraw.io",                  Description="AI music composer for royalty-free background music.",                   LogoURL="" },
        new() { Id=35, Name="AIVA",               Category="AI Music Generators",PriceINR=1660, IsFree=false, WebsiteURL="https://aiva.ai",                      Description="AI composer for emotional soundtracks and music production.",             LogoURL="" },
        new() { Id=36, Name="Salesforce Einstein",Category="AI Business Tools",  PriceINR=8300, IsFree=false, WebsiteURL="https://salesforce.com/products/einstein",Description="AI-powered CRM analytics and automation for sales teams.",           LogoURL="" },
        new() { Id=37, Name="HubSpot AI",         Category="AI Business Tools",  PriceINR=4150, IsFree=false, WebsiteURL="https://hubspot.com",                  Description="AI-powered CRM for marketing, sales, and customer service.",             LogoURL="" },
        new() { Id=38, Name="Zapier AI",          Category="AI Business Tools",  PriceINR=1660, IsFree=false, WebsiteURL="https://zapier.com",                   Description="AI automation connecting thousands of apps without coding.",              LogoURL="" },
        new() { Id=39, Name="Otter.ai",           Category="AI Business Tools",  PriceINR=830,  IsFree=false, WebsiteURL="https://otter.ai",                     Description="AI meeting assistant for real-time transcription and summaries.",         LogoURL="" },
        new() { Id=40, Name="Fireflies.ai",       Category="AI Business Tools",  PriceINR=1250, IsFree=false, WebsiteURL="https://fireflies.ai",                 Description="AI notetaker for meetings across Zoom, Teams, and Google Meet.",         LogoURL="" },
        new() { Id=41, Name="Notion",             Category="AI Productivity",    PriceINR=0,    IsFree=true,  WebsiteURL="https://notion.so",                    Description="All-in-one workspace for notes, docs, and project management with AI.",   LogoURL="" },
        new() { Id=42, Name="Mem.ai",             Category="AI Productivity",    PriceINR=1660, IsFree=false, WebsiteURL="https://mem.ai",                       Description="AI-powered personal knowledge base that organizes itself.",               LogoURL="" },
        new() { Id=43, Name="Reclaim.ai",         Category="AI Productivity",    PriceINR=830,  IsFree=false, WebsiteURL="https://reclaim.ai",                   Description="AI scheduling assistant that protects focus time.",                      LogoURL="" },
        new() { Id=44, Name="ClickUp AI",         Category="AI Productivity",    PriceINR=415,  IsFree=false, WebsiteURL="https://clickup.com",                  Description="Project management with built-in AI for tasks and docs.",                 LogoURL="" },
        new() { Id=45, Name="Motion",             Category="AI Productivity",    PriceINR=1660, IsFree=false, WebsiteURL="https://usemotion.com",                 Description="AI task manager that automatically plans your day and schedule.",         LogoURL="" },
        new() { Id=46, Name="Canva AI",           Category="AI Design Tools",    PriceINR=3999, IsFree=false, WebsiteURL="https://canva.com",                    Description="Design platform with Magic AI tools for image generation and editing.",   LogoURL="" },
        new() { Id=47, Name="Figma AI",           Category="AI Design Tools",    PriceINR=1250, IsFree=false, WebsiteURL="https://figma.com",                    Description="Collaborative design tool with AI features for UI/UX workflows.",        LogoURL="" },
        new() { Id=48, Name="Uizard",             Category="AI Design Tools",    PriceINR=1250, IsFree=false, WebsiteURL="https://uizard.io",                    Description="AI design tool for wireframes and prototypes from text descriptions.",    LogoURL="" },
        new() { Id=49, Name="Locofy.ai",          Category="AI Design Tools",    PriceINR=1660, IsFree=false, WebsiteURL="https://locofy.ai",                    Description="Convert Figma and Adobe XD designs to production-ready frontend code.",  LogoURL="" },
        new() { Id=50, Name="Khroma",             Category="AI Design Tools",    PriceINR=0,    IsFree=true,  WebsiteURL="https://khroma.co",                    Description="AI color tool that learns your preferences to generate palettes.",        LogoURL="" },
    };

    private static readonly List<CategoryDto> _categories = new()
    {
        new() { Id=1,  CategoryName="AI Chatbots" },
        new() { Id=2,  CategoryName="AI Image Generators" },
        new() { Id=3,  CategoryName="AI Video Tools" },
        new() { Id=4,  CategoryName="AI Code Assistants" },
        new() { Id=5,  CategoryName="AI Writing Tools" },
        new() { Id=6,  CategoryName="AI Voice & Audio" },
        new() { Id=7,  CategoryName="AI Music Generators" },
        new() { Id=8,  CategoryName="AI Business Tools" },
        new() { Id=9,  CategoryName="AI Productivity" },
        new() { Id=10, CategoryName="AI Design Tools" },
    };

    public static List<AIWebsiteDto> GetAll() => _all;
    public static List<CategoryDto> GetCategories() => _categories;
    public static List<AIWebsiteDto> GetByCategory(string cat)
        => _all.Where(x => x.Category.Equals(cat, StringComparison.OrdinalIgnoreCase)).ToList();
    public static AIWebsiteDto? GetById(int id) => _all.FirstOrDefault(x => x.Id == id);
    public static List<AIWebsiteDto> Search(string q)
        => _all.Where(x =>
            x.Name.Contains(q, StringComparison.OrdinalIgnoreCase) ||
            x.Description.Contains(q, StringComparison.OrdinalIgnoreCase) ||
            x.Category.Contains(q, StringComparison.OrdinalIgnoreCase)).ToList();
}
