<template>
    <div>
        <div ref="draggableElement" class="draggable-element" @mousedown="onMouseDown">
            Drag me!
        </div>
    </div>
</template>
  
<script>
import interact from 'interactjs';

export default {
    mounted() {
        interact(this.$refs.draggableElement)
            .draggable({
                listeners: {
                    move: this.onDragMove
                }
            });
    },
    methods: {
        onMouseDown(event) {
            // Prevent native dragging behavior
            event.preventDefault();
        },
        onDragMove(event) {
            const target = event.target;
            const x = (parseFloat(target.getAttribute('data-x')) || 0) + event.dx;
            const y = (parseFloat(target.getAttribute('data-y')) || 0) + event.dy;

            target.style.transform = `translate(${x}px, ${y}px)`;
            target.setAttribute('data-x', x);
            target.setAttribute('data-y', y);
        }
    }
};
</script>
  
<style scoped>
.draggable-element {
    width: 200px;
    height: 200px;
    background-color: #f2f2f2;
    border: 1px solid #ccc;
    cursor: move;
}
</style>
  