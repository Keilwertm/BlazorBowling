---
# Note: GitHub Pages placeholder for BlazorBowling
# This placeholder allows GitHub Pages to build successfully while you decide how to publish the Blazor WebAssembly app output into /docs.
# If you later publish the built app to /docs, keep the `.nojekyll` file to prevent GitHub Pages from processing Blazor's _framework files.
layout: default
title: BlazorBowling
---

# BlazorBowling

This is a temporary landing page for GitHub Pages.

Your Pages site is configured to use the /docs folder. Since this repository is a Blazor WebAssembly app, you typically need to publish the app and place the published files into the `docs` folder.

Next steps you can use locally to publish to docs:

1. Build a Release publish of the Blazor WASM app:
   - From the solution folder, run:
     - `dotnet publish -c Release -o publish`
2. Copy the contents of the publish `wwwroot` into the `docs` folder:
   - Copy everything from `publish/wwwroot/*` into `docs/`.
3. Commit and push. Ensure `.nojekyll` remains in `docs`.

Alternatively, change your GitHub Pages settings to serve from the root or a `gh-pages` branch and use an action to deploy.

If you see this page, the placeholder is working and the previous Jekyll error about missing `/docs` should be resolved.