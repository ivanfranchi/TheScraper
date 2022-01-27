<template>
    <div class="home">
        <h1>{{ msg }}</h1>
        <p>Welcome to your new single-page application, built with <a href="https://vuejs.org" target="_blank">Vue.js</a> and <a href="http://www.typescriptlang.org/" target="_blank">TypeScript</a>.</p>

        <!-- slam input box for search phrase (land registry search) -->
        <!-- and the url (www.infotrack.co.uk) -->
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';

    @Component
    export default class Home extends Vue {
        @Prop() private msg!: string;
        reply: string = "";

        //https://localhost:44361/ScraperHome

        created() {
            console.log("created!!");

            //Vue.$http.headers.common['Access-Control-Allow-Origin'] = true;
            //Vue.$http.headers.common['Access-Control-Allow-Origin'] = '*';

            this.scrapeTheWeb();
        }

        async scrapeTheWeb(): Promise<void> {
            console.log("scraping...");

            //const response = await fetch("https://localhost:44361/ScraperHome/GetScrapeInformation");
            let textToFind = "www.infotrack.co.uk";
            const response = await fetch(`https://localhost:44361/ScraperHome/GetScrapeInfo/${textToFind}`);
            if (response.ok) {
                console.log('ok!!');
                const body = await response.text();
                console.dir(body)
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
