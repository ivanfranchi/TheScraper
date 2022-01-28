<template>
    <div class="home">
        <h1>{{ msg }}</h1>

        <h3>Insert the text to lookup:</h3>
        <input v-model="searchText" placeholder="www.infotrack.co.uk">
        <p>(to be copy pasted) www.infotrack.co.uk</p>

        <hr />

        <h3>Separate your keywords with a space:</h3>
        <input v-model="searchKeywords" placeholder="land registry searches">
        <p>(to be copy pasted) land registry searches</p>

        <hr />

        <button @click="scrapeThis">Go Scrape!</button>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';

    @Component
    export default class Home extends Vue {
        @Prop() private msg!: string;
        reply: string = "";
        searchText: string = "";
        searchKeywords: string = "";

        created() {
        }

        public async scrapeThis(): Promise<void> {
            console.log(this.searchText);
            console.log(this.searchKeywords);
            await this.scrapeTheWeb(this.searchText, this.searchKeywords);
        }

        private async scrapeTheWeb(textToFind: string, keywordsToSearch: string): Promise<void> {
            //let textToFind = "www.infotrack.co.uk";
            //let keywordsToSearch = "land registry searches";
            const response = await fetch(`https://localhost:44361/ScraperHome/GetScrapeInfo/${textToFind}/${keywordsToSearch}`);
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
