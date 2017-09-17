var data = {
    "basic": "" +
    ".animated {<br/>" +
    "    -webkit-animation-duration: 1s;<br/>" +
    "    animation-duration: 1s;<br/>" +
    "    -webkit-animation-fill-mode: both;<br/>" +
    "    animation-fill-mode: both;<br/>" +
    "}<br/><br/>" +
    "    .animated.infinite {<br/>" +
    "        -webkit-animation-iteration-count: infinite;<br/>" +
    "        animation-iteration-count: infinite;<br/>" +
    "    }<br/><br/>" +
    "    .animated.hinge {<br/>" +
    "        -webkit-animation-duration: 2s;<br/>" +
    "        animation-duration: 2s;<br/>" +
    "    }<br/>" +
    "	"
,
    "bounce": "<br/>" +
"@-webkit-keyframes bounce {<br/>" +
"    0%,100%,20%,53%,80% {<br/>" +
"        -webkit-transition-timing-function: cubic-bezier(0.215,.61,.355,1);<br/>" +
"        transition-timing-function: cubic-bezier(0.215,.61,.355,1);<br/>" +
"        -webkit-transform: translate3d(0,0,0);<br/>" +
"        transform: translate3d(0,0,0);<br/>" +
"    }<br/>" +
"    40%,43% {<br/>" +
"        -webkit-transition-timing-function: cubic-bezier(0.755,.050,.855,.060);<br/>" +
"        transition-timing-function: cubic-bezier(0.755,.050,.855,.060);<br/>" +
"        -webkit-transform: translate3d(0,-30px,0);<br/>" +
"        transform: translate3d(0,-30px,0);<br/>" +
"    }<br/>" +
"    70% {<br/>" +
"        -webkit-transition-timing-function: cubic-bezier(0.755,.050,.855,.060);<br/>" +
"        transition-timing-function: cubic-bezier(0.755,.050,.855,.060);<br/>" +
"        -webkit-transform: translate3d(0,-15px,0);<br/>" +
"        transform: translate3d(0,-15px,0);<br/>" +
"    }<br/>" +
"    90% {<br/>" +
"        -webkit-transform: translate3d(0,-4px,0);<br/>" +
"        transform: translate3d(0,-4px,0);<br/>" +
"    }<br/>" +
"}<br/>" +
"@keyframes bounce {<br/>" +
"    0%,100%,20%,53%,80% {<br/>" +
"        -webkit-transition-timing-function: cubic-bezier(0.215,.61,.355,1);<br/>" +
"        transition-timing-function: cubic-bezier(0.215,.61,.355,1);<br/>" +
"        -webkit-transform: translate3d(0,0,0);<br/>" +
"        -ms-transform: translate3d(0,0,0);<br/>" +
"        transform: translate3d(0,0,0);<br/>" +
"    }<br/>" +
"    40%,43% {<br/>" +
"        -webkit-transition-timing-function: cubic-bezier(0.755,.050,.855,.060);<br/>" +
"        transition-timing-function: cubic-bezier(0.755,.050,.855,.060);<br/>" +
"        -webkit-transform: translate3d(0,-30px,0);<br/>" +
"        -ms-transform: translate3d(0,-30px,0);<br/>" +
"        transform: translate3d(0,-30px,0);<br/>" +
"    }<br/>" +
"    70% {<br/>" +
"        -webkit-transition-timing-function: cubic-bezier(0.755,.050,.855,.060);<br/>" +
"        transition-timing-function: cubic-bezier(0.755,.050,.855,.060);<br/>" +
"        -webkit-transform: translate3d(0,-15px,0);<br/>" +
"        -ms-transform: translate3d(0,-15px,0);<br/>" +
"        transform: translate3d(0,-15px,0);<br/>" +
"    }<br/>" +
"    90% {<br/>" +
"        -webkit-transform: translate3d(0,-4px,0);<br/>" +
"        -ms-transform: translate3d(0,-4px,0);<br/>" +
"        transform: translate3d(0,-4px,0);<br/>" +
"    }<br/>" +
"}<br/>" +
".bounce {<br/>" +
"    -webkit-animation-name: bounce;<br/>" +
"    animation-name: bounce;<br/>" +
"    -webkit-transform-origin: center bottom;<br/>" +
"    -ms-transform-origin: center bottom;<br/>" +
"    transform-origin: center bottom;<br/>" +
"}<br/>"
,
    "flash": "" +
"        @-webkit-keyframes flash {<br/>" +
"    0%,100%,50% {<br/>" +
"    opacity: 1;<br/>" +
"}<br/>" +
"25%,75% {<br/>" +
"    opacity: 0;<br/>" +
"}<br/><br/>" +
"}<br/><br/>" +
"@keyframes flash {<br/>" +
"    0%,100%,50% {<br/>" +
"        opacity: 1;<br/>" +
"}<br/><br/>" +
"25%,75% {<br/>" +
"    opacity: 0;<br/>" +
"}<br/>" +
"}<br/><br/>" +

".flash {<br/>" +
"    -webkit-animation-name: flash;<br/>" +
"    animation-name: flash;<br/>" +
"}<br/><br/>" +
"@-webkit-keyframes pulse {<br/>" +
"    0% {<br/>" +
"        -webkit-transform: scale3d(1,1,1);<br/>" +
"    transform: scale3d(1,1,1);<br/>" +
"}<br/><br/>" +
"50% {<br/>" +
"    -webkit-transform: scale3d(1.05,1.05,1.05);<br/>" +
"transform: scale3d(1.05,1.05,1.05);<br/>" +
"}<br/><br/>" +
"100% {<br/>" +
"    -webkit-transform: scale3d(1,1,1);<br/>" +
"transform: scale3d(1,1,1);<br/>" +
"}<br/>" +
"}<br/>",
    "pulse": "" +
"@-webkit-keyframes pulse {<br/>" +
"    0% {<br/>" +
"        -webkit-transform: scale3d(1,1,1);<br/>" +
"transform: scale3d(1,1,1);<br/>" +
"}<br/>" +
"50% {<br/>" +
"    -webkit-transform: scale3d(1.05,1.05,1.05);<br/>" +
"transform: scale3d(1.05,1.05,1.05);<br/>" +
"}<br/>" +
"100% {<br/>" +
"    -webkit-transform: scale3d(1,1,1);<br/>" +
"transform: scale3d(1,1,1);<br/>" +
"}<br/>" +
"}<br/>" +
"@keyframes pulse {<br/>" +
"    0% {<br/>" +
"        -webkit-transform: scale3d(1,1,1);<br/>" +
"    -ms-transform: scale3d(1,1,1);<br/>" +
"    transform: scale3d(1,1,1);<br/>" +
"}<br/>" +
"50% {<br/>" +
"    -webkit-transform: scale3d(1.05,1.05,1.05);<br/>" +
"-ms-transform: scale3d(1.05,1.05,1.05);<br/>" +
"transform: scale3d(1.05,1.05,1.05);<br/>" +
"}<br/>" +
"100% {<br/>" +
"    -webkit-transform: scale3d(1,1,1);<br/>" +
"-ms-transform: scale3d(1,1,1);<br/>" +
"transform: scale3d(1,1,1);<br/>" +
"}<br/>" +
"}<br/>" +
".pulse {<br/>" +
"    -webkit-animation-name: pulse;<br/>" +
"    animation-name: pulse;<br/>" +
"}<br/>" +
"}<br/>",
    "rubberBand": "" +
"        @-webkit-keyframes rubberBand {<br/>" +
"    0% {<br/>" +
"        -webkit-transform: scale3d(1,1,1);<br/>" +
"transform: scale3d(1,1,1);<br/>" +
"}<br/>" +
"30% {<br/>" +
"    -webkit-transform: scale3d(1.25,.75,1);<br/>" +
"transform: scale3d(1.25,.75,1);<br/>" +
"}<br/>" +
"40% {<br/>" +
"    -webkit-transform: scale3d(0.75,1.25,1);<br/>" +
"transform: scale3d(0.75,1.25,1);<br/>" +
"}<br/>" +
"50% {<br/>" +
"    -webkit-transform: scale3d(1.15,.85,1);<br/>" +
"transform: scale3d(1.15,.85,1);<br/>" +
"}<br/>" +
"65% {<br/>" +
"    -webkit-transform: scale3d(.95,1.05,1);<br/>" +
"transform: scale3d(.95,1.05,1);<br/>" +
"}<br/>" +
"75% {<br/>" +
"    -webkit-transform: scale3d(1.05,.95,1);<br/>" +
"transform: scale3d(1.05,.95,1);<br/>" +
"}<br/>" +
"100% {<br/>" +
"    -webkit-transform: scale3d(1,1,1);<br/>" +
"transform: scale3d(1,1,1);<br/>" +
"}<br/>" +
"}<br/>" +

"@keyframes rubberBand {<br/>" +
"    0% {<br/>" +
"        -webkit-transform: scale3d(1,1,1);<br/>" +
"    -ms-transform: scale3d(1,1,1);<br/>" +
"    transform: scale3d(1,1,1);<br/>" +
"}<br/>" +
"30% {<br/>" +
"    -webkit-transform: scale3d(1.25,.75,1);<br/>" +
"-ms-transform: scale3d(1.25,.75,1);<br/>" +
"transform: scale3d(1.25,.75,1);<br/>" +
"}<br/>" +
"40% {<br/>" +
"    -webkit-transform: scale3d(0.75,1.25,1);<br/>" +
"-ms-transform: scale3d(0.75,1.25,1);<br/>" +
"transform: scale3d(0.75,1.25,1);<br/>" +
"}<br/>" +
"50% {<br/>" +
"    -webkit-transform: scale3d(1.15,.85,1);<br/>" +
"-ms-transform: scale3d(1.15,.85,1);<br/>" +
"transform: scale3d(1.15,.85,1);<br/>" +
"}<br/>" +
"65% {<br/>" +
"    -webkit-transform: scale3d(.95,1.05,1);<br/>" +
"-ms-transform: scale3d(.95,1.05,1);<br/>" +
"transform: scale3d(.95,1.05,1);<br/>" +
"}<br/>" +
"75% {<br/>" +
"    -webkit-transform: scale3d(1.05,.95,1);<br/>" +
"-ms-transform: scale3d(1.05,.95,1);<br/>" +
"transform: scale3d(1.05,.95,1);<br/>" +
"}<br/>" +
"100% {<br/>" +
"    -webkit-transform: scale3d(1,1,1);<br/>" +
"-ms-transform: scale3d(1,1,1);<br/>" +
"transform: scale3d(1,1,1);<br/>" +
"}<br/>" +
"}<br/>" +
".rubberBand {<br/>" +
"    -webkit-animation-name: rubberBand;<br/>" +
"    animation-name: rubberBand<br/>" +
"}<br/>" +
"}<br/>",
    "shake": "" +
"        @-webkit-keyframes shake {<br/>" +
"    0%,100% {<br/>" +
"        -webkit-transform: translate3d(0,0,0);<br/>" +
"transform: translate3d(0,0,0);<br/>" +
"}<br/>" +
"10%,30%,50%,70%,90% {<br/>" +
"    -webkit-transform: translate3d(-10px,0,0);<br/>" +
"transform: translate3d(-10px,0,0);<br/>" +
"}<br/>" +
"20%,40%,60%,80% {<br/>" +
"    -webkit-transform: translate3d(10px,0,0);<br/>" +
"transform: translate3d(10px,0,0);<br/>" +
"}<br/>" +
"}<br/>" +
"@keyframes shake {<br/>" +
"    0%,100% {<br/>" +
"        -webkit-transform: translate3d(0,0,0);<br/>" +
"    -ms-transform: translate3d(0,0,0);<br/>" +
"    transform: translate3d(0,0,0);<br/>" +
"}<br/>" +
"10%,30%,50%,70%,90% {<br/>" +
"    -webkit-transform: translate3d(-10px,0,0);<br/>" +
"-ms-transform: translate3d(-10px,0,0);<br/>" +
"transform: translate3d(-10px,0,0);<br/>" +
"}<br/>" +
"20%,40%,60%,80% {<br/>" +
"    -webkit-transform: translate3d(10px,0,0);<br/>" +
"-ms-transform: translate3d(10px,0,0);<br/>" +
"transform: translate3d(10px,0,0);<br/>" +
"}<br/>" +
"}<br/>" +
".shake {<br/>" +
"    -webkit-animation-name: shake;<br/>" +
"    animation-name: shake;<br/>" +
"}<br/>" +
"}<br/>",
    "swing": "" +
"@-webkit-keyframes swing {<br/>" +
"    20% {<br/>" +
"        -webkit-transform: rotate3d(0,0,1,15deg);<br/>" +
"transform: rotate3d(0,0,1,15deg);<br/>" +
"}<br/>" +
"40% {<br/>" +
"    -webkit-transform: rotate3d(0,0,1,-10deg);<br/>" +
"transform: rotate3d(0,0,1,-10deg);<br/>" +
"}<br/>" +
"60% {<br/>" +
"    -webkit-transform: rotate3d(0,0,1,5deg);<br/>" +
"transform: rotate3d(0,0,1,5deg);<br/>" +
"}<br/>" +
"80% {<br/>" +
"    -webkit-transform: rotate3d(0,0,1,-5deg);<br/>" +
"transform: rotate3d(0,0,1,-5deg);<br/>" +
"}<br/>" +
"100% {<br/>" +
"    -webkit-transform: rotate3d(0,0,1,0deg);<br/>" +
"transform: rotate3d(0,0,1,0deg);<br/>" +
"}<br/>" +
"}<br/>" +
"@keyframes swing {<br/>" +
"    20% {<br/>" +
"        -webkit-transform: rotate3d(0,0,1,15deg);<br/>" +
"    -ms-transform: rotate3d(0,0,1,15deg);<br/>" +
"    transform: rotate3d(0,0,1,15deg);<br/>" +
"}<br/>" +
"40% {<br/>" +
"    -webkit-transform: rotate3d(0,0,1,-10deg);<br/>" +
"-ms-transform: rotate3d(0,0,1,-10deg);<br/>" +
"transform: rotate3d(0,0,1,-10deg);<br/>" +
"}<br/>" +
"60% {<br/>" +
"    -webkit-transform: rotate3d(0,0,1,5deg);<br/>" +
"-ms-transform: rotate3d(0,0,1,5deg);<br/>" +
"transform: rotate3d(0,0,1,5deg);<br/>" +
"}<br/>" +
"80% {<br/>" +
"    -webkit-transform: rotate3d(0,0,1,-5deg);<br/>" +
"-ms-transform: rotate3d(0,0,1,-5deg);<br/>" +
"transform: rotate3d(0,0,1,-5deg);<br/>" +
"}<br/>" +
"100% {<br/>" +
"    -webkit-transform: rotate3d(0,0,1,0deg);<br/>" +
"-ms-transform: rotate3d(0,0,1,0deg);<br/>" +
"transform: rotate3d(0,0,1,0deg);<br/>" +
"}<br/>" +
"}<br/>" +
".swing {<br/>" +
"    -webkit-transform-origin: top center;<br/>" +
"    -ms-transform-origin: top center;<br/>" +
"    transform-origin: top center;<br/>" +
"    -webkit-animation-name: swing;<br/>" +
"    animation-name: swing;<br/>" +
"}<br/>" +
"}<br/>"
}

