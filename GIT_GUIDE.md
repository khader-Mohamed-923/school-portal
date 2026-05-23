# Git Commit Guide - SchoolPortal

Quick reference guide for committing your SchoolPortal project to GitHub.

## 🚀 Quick Start (Recommended)

### Option 1: Automated Full Commit
```cmd
git-commit-all.bat
```
This script will:
- Initialize Git repository (if needed)
- Let you choose between single or structured commits
- Optionally push to GitHub
- Show commit history

### Option 2: Quick Custom Commit
```cmd
git-quick-commit.bat
```
This script will:
- Stage all changes
- Let you enter a custom commit message
- Optionally push to GitHub

### Option 3: Manual Commands
```cmd
git init
git add .
git commit -m "feat: implement SchoolPortal microservices architecture"
git remote add origin https://github.com/YOUR_USERNAME/YOUR_REPO.git
git push -u origin main
```

---

## 📝 Commit Strategies

### Strategy 1: Single Commit (Fastest)
**Best for**: Initial project upload, simple history

**Message**:
```
feat: implement SchoolPortal microservices architecture

- Add Students microservice with CRUD operations and API endpoints
- Add Grades microservice with inter-service communication
- Implement Entity Framework Core with automatic migrations
- Add Docker containerization with multi-stage builds
- Configure Docker Compose for service orchestration
- Add modern Tailwind CSS UI with responsive design
- Include comprehensive documentation and setup guides
```

**Commands**:
```cmd
git add .
git commit -m "feat: implement SchoolPortal microservices architecture"
```

---

### Strategy 2: Structured Commits (Most Detailed)
**Best for**: Clear project history, team collaboration

**13 Commits**:
1. `chore: initialize project structure and configuration`
2. `feat(students): implement Students microservice with CRUD operations`
3. `feat(students): add Entity Framework migrations for Students database`
4. `feat(students): add Razor views with modern Tailwind CSS design`
5. `feat(grades): implement Grades microservice with CRUD operations`
6. `feat(grades): add HTTP client for Students service validation`
7. `feat(grades): add Entity Framework migrations for Grades database`
8. `feat(grades): add Razor views with modern Tailwind CSS design`
9. `build(docker): add Dockerfile for Students service`
10. `build(docker): add Dockerfile for Grades service`
11. `build(docker): add docker-compose for multi-service orchestration`
12. `docs: add comprehensive README with setup and usage instructions`
13. `chore: add commit roadmap and deployment scripts`

**Use the script**: `git-commit-all.bat` and choose option 2

---

## 🔗 Setting Up GitHub Repository

### Step 1: Create Repository on GitHub
1. Go to https://github.com/new
2. Enter repository name: `SchoolPortal` (or your choice)
3. Choose Public or Private
4. **DO NOT** initialize with README (we already have one)
5. Click "Create repository"

### Step 2: Connect Local to GitHub
```cmd
git remote add origin https://github.com/YOUR_USERNAME/SchoolPortal.git
git branch -M main
git push -u origin main
```

### Step 3: Verify
Visit your repository URL to see your code!

---

## 🛠️ Common Git Commands

### Check Status
```cmd
git status
```

### View Commit History
```cmd
git log --oneline --graph
```

### View Recent Commits
```cmd
git log --oneline -5
```

### Undo Last Commit (Keep Changes)
```cmd
git reset --soft HEAD~1
```

### Undo Last Commit (Discard Changes)
```cmd
git reset --hard HEAD~1
```

### View Changes
```cmd
git diff
```

### Add Specific Files
```cmd
git add README.md docker-compose.yml
```

### Commit with Detailed Message
```cmd
git commit -m "Title" -m "Description line 1" -m "Description line 2"
```

### Push to Remote
```cmd
git push origin main
```

### Pull from Remote
```cmd
git pull origin main
```

---

## 🌿 Branch Strategy (Optional)

### Create Feature Branch
```cmd
git checkout -b feature/new-feature
```

### Switch Branches
```cmd
git checkout main
git checkout feature/new-feature
```

### Merge Branch
```cmd
git checkout main
git merge feature/new-feature
```

### Delete Branch
```cmd
git branch -d feature/new-feature
```

---

## ⚠️ Important Notes

### Before Committing
1. ✅ Review `.gitignore` - ensure secrets are excluded
2. ✅ Check `git status` - verify what will be committed
3. ✅ Test the application - ensure it works
4. ✅ Remove sensitive data - no passwords or API keys

### Files Excluded by .gitignore
- `bin/` and `obj/` folders
- `.vs/` and `.vscode/` folders
- `*.env` and `secret.env` files
- `*.log` files
- SQL Server database files (`.mdf`, `.ldf`)
- User-specific files

### Sensitive Files to Check
- ❌ `secret.env` - Should NOT be committed (already in .gitignore)
- ✅ `appsettings.json` - Safe (uses LocalDB)
- ✅ `docker-compose.yml` - Safe (example password, should be changed in production)

---

## 🔐 Security Checklist

Before pushing to GitHub:

- [ ] No real passwords in configuration files
- [ ] No API keys or tokens in code
- [ ] `.gitignore` is properly configured
- [ ] `secret.env` is excluded
- [ ] Connection strings use example/default passwords
- [ ] No personal information in commits

---

## 📚 Conventional Commits Reference

Format: `<type>(<scope>): <description>`

**Types**:
- `feat`: New feature
- `fix`: Bug fix
- `docs`: Documentation only
- `style`: Formatting, missing semicolons, etc.
- `refactor`: Code change that neither fixes a bug nor adds a feature
- `perf`: Performance improvement
- `test`: Adding tests
- `build`: Build system or dependencies
- `ci`: CI/CD changes
- `chore`: Maintenance tasks

**Examples**:
```
feat(students): add email validation
fix(grades): resolve null reference exception
docs: update README with API documentation
build(docker): optimize Dockerfile layer caching
```

---

## 🆘 Troubleshooting

### "fatal: not a git repository"
```cmd
git init
```

### "fatal: remote origin already exists"
```cmd
git remote remove origin
git remote add origin YOUR_URL
```

### "failed to push some refs"
```cmd
git pull origin main --rebase
git push origin main
```

### "Permission denied (publickey)"
Set up SSH key or use HTTPS with personal access token:
https://docs.github.com/en/authentication

### Accidentally committed sensitive data
```cmd
# Remove from last commit
git rm --cached secret.env
git commit --amend -m "Remove sensitive file"

# If already pushed, see: https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/removing-sensitive-data-from-a-repository
```

---

## 📞 Need Help?

- Git Documentation: https://git-scm.com/doc
- GitHub Guides: https://guides.github.com/
- Conventional Commits: https://www.conventionalcommits.org/

---

**Happy Coding! 🚀**
