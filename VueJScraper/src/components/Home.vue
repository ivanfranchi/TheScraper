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

        <h3>How many results per page?</h3>
        <input v-model="resultAmount">

        <hr />

        <button @click="scrapeThis">Go Scrape!</button>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';

    @Component
    export default class Home extends Vue {
        @Prop() private msg!: string;
        baseUrl: string = "https://localhost:44361/"
        reply: string = "";
        searchText: string = "";
        searchKeywords: string = "";
        resultAmount: string = "5";

        created() {
        }

        public async scrapeThis(): Promise<void> {
            if (this.searchText == "") {
                this.searchText = "www.infotrack.co.uk";
            }
            if (this.searchKeywords == "") {
                this.searchKeywords = "land registry searches";
            }
            await this.scrapeTheWeb(this.searchText, this.searchKeywords, this.resultAmount);
        }

        private async scrapeTheWeb(textToFind: string, keywordsToSearch: string, howMany: string): Promise<void> {
            try {
                const response =
                    await fetch(`${this.baseUrl}ScraperHome/GetScrapeInfo/${textToFind}/${keywordsToSearch}/${howMany}`);

                if (response.ok) {
                    console.log('ok!!');
                    const body = await response.text();
                    console.dir(body)
                } else {
                    console.error(await response.text());
                }
            } catch (err) {
                console.error(JSON.stringify(err));
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
