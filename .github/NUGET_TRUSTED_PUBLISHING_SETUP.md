# NuGet Trusted Publishing Setup Guide

This repository uses NuGet Trusted Publishing for secure, keyless package publishing. This eliminates the need for long-lived API keys and uses OpenID Connect (OIDC) for authentication.

## What is NuGet Trusted Publishing?

NuGet Trusted Publishing allows you to publish packages to NuGet.org from GitHub Actions without storing API keys as secrets. Instead, GitHub provides a short-lived OIDC token that NuGet.org validates to issue a temporary API key for the publishing operation.

### Benefits:
- **No secrets to manage**: No need to create, rotate, or secure long-lived API keys
- **Enhanced security**: Short-lived tokens reduce the risk of credential leaks
- **Simplified workflow**: Automatic authentication through OIDC

## Setup Instructions

### Step 1: Configure Trusted Publishing Policy on NuGet.org

1. Log into [nuget.org](https://www.nuget.org/)
2. Click on your username and select **API Keys** or navigate to your account settings
3. Find the **Trusted Publishing** section (may be under a separate tab or menu)
4. Click **Add a new policy** or similar button
5. Fill in the policy details:
   - **Repository Owner**: `jfversluis`
   - **Repository Name**: `Template.Maui.UITesting`
   - **Workflow File**: `release-nuget.yml` (❗ Do NOT include `.github/workflows/` path)
   - **Environment** (optional): Leave blank unless you want to restrict to a specific GitHub environment

### Step 2: Create GitHub Secret for NuGet Username

1. Go to the repository on GitHub: https://github.com/jfversluis/Template.Maui.UITesting
2. Navigate to **Settings** → **Secrets and variables** → **Actions**
3. Click **New repository secret**
4. Create a secret with:
   - **Name**: `NUGET_USERNAME`
   - **Value**: Your NuGet.org username

### Step 3: Verify Workflow Configuration

The workflow file `.github/workflows/release-nuget.yml` has been configured with:
- ✅ `permissions: id-token: write` - Required for OIDC token generation
- ✅ `NuGet/login@v1` action - Exchanges OIDC token for temporary API key
- ✅ Uses `${{ secrets.NUGET_USERNAME }}` for authentication
- ✅ Uses temporary API key from login step for publishing

### Step 4: Remove Old API Key Secret (Optional but Recommended)

Once Trusted Publishing is working, you can safely remove the old `NUGET_API_KEY` secret:
1. Go to **Settings** → **Secrets and variables** → **Actions**
2. Find `NUGET_API_KEY` and delete it

## Testing the Workflow

To test that Trusted Publishing is working:

1. Create a tag following the version pattern (e.g., `v1.2.3` or `v1.2.3-preview1`)
2. Push the tag to trigger the release workflow
3. Monitor the workflow run in the Actions tab
4. The "NuGet Login (OIDC)" step should succeed and obtain a temporary API key
5. The "Push to NuGet.org" step should successfully publish the package

## Troubleshooting

### "Unable to obtain OIDC token" error
- Ensure `permissions: id-token: write` is set in the workflow
- Check that the workflow is running from the correct branch/tag

### "Authentication failed" error
- Verify the Trusted Publishing policy on NuGet.org matches exactly:
  - Repository owner: `jfversluis`
  - Repository name: `Template.Maui.UITesting`
  - Workflow file: `release-nuget.yml` (no path prefix)
- Ensure the `NUGET_USERNAME` secret is set correctly

### "Package already exists" error
- This is expected if you're trying to re-publish the same version
- Version numbers on NuGet.org are immutable; you need to increment the version

## Additional Resources

- [NuGet Trusted Publishing Documentation](https://learn.microsoft.com/en-us/nuget/nuget-org/trusted-publishing)
- [NuGet/login GitHub Action](https://github.com/marketplace/actions/nuget-login)
- [GitHub Actions OIDC Documentation](https://docs.github.com/en/actions/deployment/security-hardening-your-deployments/about-security-hardening-with-openid-connect)
