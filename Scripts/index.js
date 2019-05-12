import Vue from 'vue/dist/vue.js';

import FullCalendar from '@fullcalendar/vue'
import dayGridPlugin from '@fullcalendar/daygrid'
import timeGridPlugin from '@fullcalendar/timegrid'
import interactionPlugin from '@fullcalendar/interaction'


// import Calendar from './Calendar.js'

// new Vue({
//     render: h => h(Calendar)
// }).$mount('#calendar')





// Vue.component('calendar');

Vue.component('calendar', {
    template: `
        <FullCalendar
            class='demo-app-calendar'
            ref="fullCalendar"
            defaultView="dayGridMonth"
            :header="{
                left: 'prev,next today',
                center: 'title',
                right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
            }"
            :plugins="calendarPlugins"
            :weekends="calendarWeekends"
            :events="calendarEvents"
            @@dateClick="handleDateClick"
        />
    `,
    components: {
        FullCalendar // make the <FullCalendar> tag available
    },
    data: function() {
        return {
            calendarPlugins: [ // plugins must be defined in the JS
                dayGridPlugin,
                timeGridPlugin,
                interactionPlugin // needed for dateClick
            ],
            calendarWeekends: true,
            calendarEvents: [ // initial event data
                { title: 'Event Now', start: new Date() }
            ]
        }
    },
    methods: {
        toggleWeekends() {
            this.calendarWeekends = !this.calendarWeekends // update a property
        },
        gotoPast() {
            let calendarApi = this.$refs.fullCalendar.getApi() // from the ref="..."
            calendarApi.gotoDate('2000-01-01') // call a method on the Calendar object
        },
        handleDateClick(arg) {
            if (confirm('Would you like to add an event to ' + arg.dateStr + ' ?')) {
                this.calendarEvents.push({ // add new event data
                    title: 'New Event',
                    start: arg.date,
                    allDay: arg.allDay
                })
            }
        }
    }
});

Vue.component('export-modal', {
    data() {
        return {
            exportData: 'all',
            fileFormat: 'pdf',
        }
    },
    computed: {
        exportAllData() {
            return this.exportData == 'all' ? 'btn-dark' : 'btn-link';
        },
        exportFilteredData() {
            return this.exportData == 'filtered' ? 'btn-dark' : 'btn-link';
        },
        pdfFileFormat() {
            return this.fileFormat == 'pdf' ? 'btn-dark' : 'btn-link';
        },
        csvFileFormat() {
            return this.fileFormat == 'csv' ? 'btn-dark' : 'btn-link';
        },
        jsonFileFormat() {
            return this.fileFormat == 'json' ? 'btn-dark' : 'btn-link';
        },
        exportDataClass(element) {
            return this.exportData == element ? 'btn-dark' : 'btn-link';
        }
    }
});

Vue.component('related-to-toggler', {
    data() {
        return {
            togglerOn: false,
        }
    },
    computed: {
        togglerText() {
            return this.togglerOn ? 'taip' : 'ne';
        }
    }
});

new Vue({
    el: '#app-root',
    data() {
        return {
            currentViewMode: '',
            initialViewMode: true,
            sidebarEquipmentActive: false,
        }
    },
    methods: {
        changeViewMode(mode) {
            this.initialViewMode = false;
            this.currentViewMode = mode;
        },
    },
    computed: {
        listViewMode() {
            return this.currentViewMode == 'list' ? 'active' : '';
        },
        tableViewMode() {
            return this.currentViewMode == 'table' ? 'active' : '';
        },
        calendarViewMode() {
            return this.currentViewMode == 'calendar' ? 'active' : '';
        },
        gridViewMode() {
            return this.currentViewMode == 'grid' ? 'active' : '';
        },
    }
});



// new Vue({
//     el: '#calendar',
//     components: {
//         FullCalendar
//     },
//     data: function() {
//         return {
//                 calendarPlugins: [ // plugins must be defined in the JS
//                 dayGridPlugin,
//                 timeGridPlugin,
//                 interactionPlugin // needed for dateClick
//             ],
//             calendarWeekends: true,
//             calendarEvents: [ // initial event data
//                 { title: 'Event Now', start: new Date() }
//             ]
//         }
//     },
//     methods: {
//         toggleWeekends() {
//             this.calendarWeekends = !this.calendarWeekends // update a property
//         },
//         gotoPast() {
//             let calendarApi = this.$refs.fullCalendar.getApi() // from the ref="..."
//             calendarApi.gotoDate('2000-01-01') // call a method on the Calendar object
//         },
//         handleDateClick(arg) {
//             if (confirm('Would you like to add an event to ' + arg.dateStr + ' ?')) {
//                 this.calendarEvents.push({ // add new event data
//                     title: 'New Event',
//                     start: arg.date,
//                     allDay: arg.allDay
//                 })
//             }
//         }
//     }
// });






// import Calendar from './Calendar.vue'





// Vue.component('Calendar');

// new Vue({
    // el: '#demo-app-placeholder'
// });





// new Vue({
//     render: h => h(Calendar)
// }).$mount('#demo-app-placeholder')





// new Vue({
//     el: '#demo-app-placeholder',
//     render: function (h) {
//         return h(require('./Calendar.vue'));
//     }
// });



