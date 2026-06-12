// Planning Editor - Block-based Notion-like editor for Blazor Server
// Uses event delegation to handle contenteditable interactions
window.PlanningEditor = {
    _dotNetRef: null,
    _containerId: null,
    _debounceTimers: {},
    _initialized: false,

    init: function (dotNetRef, containerId) {
        this._dotNetRef = dotNetRef;
        this._containerId = containerId;
        
        const container = document.getElementById(containerId);
        if (!container || this._initialized) return;
        this._initialized = true;

        // Use event delegation on the container
        container.addEventListener('keydown', (e) => this._handleKeyDown(e), true);
        container.addEventListener('input', (e) => this._handleInput(e), true);
        container.addEventListener('focus', (e) => this._handleFocus(e), true);
        container.addEventListener('paste', (e) => this._handlePaste(e), true);
        container.addEventListener('dragover', (e) => { e.preventDefault(); });
        container.addEventListener('drop', (e) => this._handleDrop(e));
    },

    reinit: function (dotNetRef) {
        this._dotNetRef = dotNetRef;
    },

    focusBlock: function (blockId, atEnd) {
        requestAnimationFrame(() => {
            const el = document.querySelector(`[data-block-id="${blockId}"]`);
            if (!el) return;
            el.focus();
            if (el.textContent.length > 0) {
                const range = document.createRange();
                const sel = window.getSelection();
                range.selectNodeContents(el);
                range.collapse(atEnd ? false : true);
                sel.removeAllRanges();
                sel.addRange(range);
            }
        });
    },

    setBlockContent: function (blockId, content) {
        const el = document.querySelector(`[data-block-id="${blockId}"]`);
        if (el) el.textContent = content;
    },

    getBlockContent: function (blockId) {
        const el = document.querySelector(`[data-block-id="${blockId}"]`);
        return el ? el.textContent : '';
    },

    getAllBlockContents: function () {
        const blocks = [];
        document.querySelectorAll('[data-block-id]').forEach(el => {
            blocks.push({
                id: parseInt(el.getAttribute('data-block-id')),
                content: el.textContent
            });
        });
        return blocks;
    },

    _getBlockId: function (el) {
        const blockEl = el.closest('[data-block-id]');
        return blockEl ? parseInt(blockEl.getAttribute('data-block-id')) : null;
    },

    _getCursorPosition: function (el) {
        const sel = window.getSelection();
        if (!sel.rangeCount) return 0;
        const range = sel.getRangeAt(0);
        const preRange = range.cloneRange();
        preRange.selectNodeContents(el);
        preRange.setEnd(range.startContainer, range.startOffset);
        return preRange.toString().length;
    },

    _handleKeyDown: function (e) {
        const blockEl = e.target.closest('[data-block-id]');
        if (!blockEl || !this._dotNetRef) return;

        const blockId = parseInt(blockEl.getAttribute('data-block-id'));
        const content = blockEl.textContent;
        const pos = this._getCursorPosition(blockEl);

        if (e.key === 'Enter' && !e.shiftKey) {
            e.preventDefault();
            this._dotNetRef.invokeMethodAsync('OnBlockEnter', blockId, content, pos);
        } else if (e.key === 'Backspace') {
            if (pos === 0 && content.length === 0) {
                e.preventDefault();
                this._dotNetRef.invokeMethodAsync('OnBlockBackspaceEmpty', blockId);
            } else if (pos === 0) {
                e.preventDefault();
                this._dotNetRef.invokeMethodAsync('OnBlockBackspaceAtStart', blockId, content);
            }
        } else if (e.key === 'ArrowUp' && pos === 0) {
            e.preventDefault();
            this._dotNetRef.invokeMethodAsync('OnBlockArrowUp', blockId);
        } else if (e.key === 'ArrowDown' && pos >= content.length) {
            e.preventDefault();
            this._dotNetRef.invokeMethodAsync('OnBlockArrowDown', blockId);
        } else if (e.key === 'Tab') {
            e.preventDefault();
            if (e.shiftKey) {
                this._dotNetRef.invokeMethodAsync('OnBlockOutdent', blockId);
            } else {
                this._dotNetRef.invokeMethodAsync('OnBlockIndent', blockId);
            }
        }
    },

    _handleInput: function (e) {
        const blockEl = e.target.closest('[data-block-id]');
        if (!blockEl || !this._dotNetRef) return;

        const blockId = parseInt(blockEl.getAttribute('data-block-id'));
        const content = blockEl.textContent;

        // Debounce content changes
        clearTimeout(this._debounceTimers[blockId]);
        this._debounceTimers[blockId] = setTimeout(() => {
            this._dotNetRef.invokeMethodAsync('OnBlockContentChanged', blockId, content);
        }, 150);
    },

    _handleFocus: function (e) {
        const blockEl = e.target.closest('[data-block-id]');
        if (!blockEl || !this._dotNetRef) return;
        const blockId = parseInt(blockEl.getAttribute('data-block-id'));
        this._dotNetRef.invokeMethodAsync('OnBlockFocused', blockId);
    },

    _handlePaste: function (e) {
        const items = (e.clipboardData || e.originalEvent?.clipboardData)?.items;
        if (!items) return;
        
        for (const item of items) {
            if (item.type.startsWith('image/')) {
                e.preventDefault();
                const file = item.getAsFile();
                this._uploadFile(file);
                return;
            }
        }
        
        // For text paste, paste as plain text only
        if (e.clipboardData?.getData('text/html')) {
            e.preventDefault();
            const text = e.clipboardData.getData('text/plain');
            document.execCommand('insertText', false, text);
        }
    },

    _handleDrop: function (e) {
        e.preventDefault();
        e.stopPropagation();
        if (e.dataTransfer?.files?.length > 0) {
            for (const file of e.dataTransfer.files) {
                this._uploadFile(file);
            }
        }
    },

    _uploadFile: async function (file) {
        if (!this._dotNetRef || !file) return;
        const maxSize = 10 * 1024 * 1024;
        if (file.size > maxSize) {
            alert('Bestand is te groot. Maximum is 10 MB.');
            return;
        }

        const reader = new FileReader();
        reader.onload = async (e) => {
            const base64 = e.target.result.split(',')[1];
            await this._dotNetRef.invokeMethodAsync('OnFilePasted', file.name, file.type, base64);
        };
        reader.readAsDataURL(file);
    },

    dispose: function () {
        this._dotNetRef = null;
        this._initialized = false;
        this._debounceTimers = {};
    }
};

// General Notes paste helper
window.GeneralNotesPaste = {
    init: function (dotNetRef, elementId) {
        const el = document.getElementById(elementId);
        if (!el) return;
        el.addEventListener('paste', function (e) {
            const items = (e.clipboardData || e.originalEvent?.clipboardData)?.items;
            if (!items) return;
            for (const item of items) {
                if (item.type.startsWith('image/') || item.type === 'application/pdf') {
                    e.preventDefault();
                    const file = item.getAsFile();
                    if (!file || file.size > 10 * 1024 * 1024) return;
                    const reader = new FileReader();
                    reader.onload = async (ev) => {
                        const base64 = ev.target.result.split(',')[1];
                        await dotNetRef.invokeMethodAsync('OnGeneralNotePasted', file.name, file.type, base64);
                    };
                    reader.readAsDataURL(file);
                    return;
                }
            }
        });
    }
};

