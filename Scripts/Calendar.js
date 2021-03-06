// import FullCalendar from '@fullcalendar/vue'
// import dayGridPlugin from '@fullcalendar/daygrid'
// import timeGridPlugin from '@fullcalendar/timegrid'
// import interactionPlugin from '@fullcalendar/interaction'

// export default {
//     components: {
//         FullCalendar // make the <FullCalendar> tag available
//     },
//     data: function() {
//         return {
//             calendarPlugins: [ // plugins must be defined in the JS
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
//                 title: 'New Event',
//                 start: arg.date,
//                 allDay: arg.allDay
//                 })
//             }
//         }
//     }
// }
