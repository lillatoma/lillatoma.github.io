+++
title = 'Setting up the website'
date = 2024-04-30T15:35:32+02:00
draft = true
+++

Setting up this website wasn't practically difficult. I was recommended the static website builder tool, called Hugo, which essentially makes static `.html` files from Markdown files. What could be hard in that, right? Well, writing the `.md` files are no trouble. However, maybe I did something wrong during the process of making this site, but I encountered a few issues, which I would like to share, in hopes, that you are also reading this, looking through the web to find a solution to your problem. Or you also want to make a website, that is.

I would love to first disclose the main points of this article:
- How to get Hugo to work
- Issues along the process

# How to get Hugo to work

I know there is a ton of articles on the internet about how to set up your own static websites using Hugo, so why would I bother with pouring another bucket of water into the ocean, right? Hell, wrong.
Let's assume, you already have Hugo installed, and you are in the folder where you want to make the project for your website. With the command `hugo new site mynewsite`, Hugo will make the main directory and the needed subdirectories for the project. You would write your `.md` files then in the `\content` folder, or you could make them using `hugo new filename.md`. This last command will make a new file in the `\content\` directory. That is basically the essence of making your website. Let's get back to the configuration of Hugo, and how to stylize it.

If you go to [https://themes.gohugo.io/](https://themes.gohugo.io/), you can browse through a number of themes, and if you find something that makes your eyes stuck, you open it, and you should find the repository link. The theme should provide some information about how to install it.
Our example is going to be the theme I currently use [Color your world](https://themes.gohugo.io/themes/hugo-theme-color-your-world/). In the installation, it provides a cmd `git clone https://gitlab.com/rmaguiar/hugo-theme-color-your-world.git themes/color-your-world`.
I installed it as a submodule using the command `git submodule add https://gitlab.com/rmaguiar/hugo-theme-color-your-world.git themes/color-your-world`. 
However, this is not yet enough. We will have to provide Hugo some snippet of information that we would like to use this theme. In the main directory of your project, you will find `hugo.toml`. 

It should look something like this, by default:
```
baseURL = 'https://example.org/'
languageCode = 'en-us'
title = 'My New Hugo Site'
```

The baseURL should be the URL to your website, including the `/` at the end of it. The rest what you see there is up to you. If you want to add a theme, you will add a new line `theme = folderName`, like `theme = color-your-world`. 

And at this point, we don't yet know how the website should appear. If you type `hugo server -D` in the console, you should be able to view your website running locally at `localhost:1313`.

If you are satisfied with what's there, you can run `hugo` that will build your website that now you can upload.... Wait, that leads right to one of the issues that I encountered. It needs some other parameters, but let's say for now, that `hugo -D` should solve the issue.

If you don't want to do this step manually, and you use GitHub pages for your website, you should check out this small article: [Hosting on GitHub](https://gohugo.io/hosting-and-deployment/hosting-on-github/). After this step, any updates to the repository will trigger this procedure, and auto-generate the website from it. You will only have to write now. :D

# Issues along the process

I probably Googled the wrong words, but I spent an embarrassing amount of time, trying to find the solution for my issues, but after a few attempts, and thinking through what the problem might be, I managed to find solution, and also salvation. (Yep, I kind of wanted to find the solution already... :D)

So you already met the solution to the first issue, but you most likely haven't seen what happens it you don't solve it. Well, the website would load properly on the local server, but on the distant server, for some reason, the CSS won't load, and things will look botched a bit. The reason for it is that the site has references to `localhost:1313` even though it is not running locally, and can't load the CSS and JS from there. Running `hugo -D` solved it for me, and all the references were correct. Note: I also edited the automation action to contain `-D` as it doesn't by default.

The second issue was that, for some reason, there was only a singular main page, and the subpages didn't load. Turns out, the artifact of the website generation showed that Hugo just left them out the process. I didn't have many pages thankfully, so it wasn't a big hassle to fix this. The solution was here [Solution](https://discourse.gohugo.io/t/hugo-is-only-generating-a-single-html-file-and-ignores-all-subfolders-of-content/45080/2) from the user by the name *jmooring*. Essentially it says that any files at the end of the hierarchy (or if you view it like a tree, then a leaf) should be `index.md` and the rest are `_index.md`. 

# Conclusion

I know, this is still a basic site, and there might be more articles on extending the website, and delving deeper into Hugo. But the beginning is always the most difficult part, and well, we're past that now, so yay! :D

If you liked this article, or you noticed something, or have any questions, feel free to reach me at [LinkedIn](https://www.linkedin.com/in/lilla-toma/).

### Related articles

None so far, sorry.


